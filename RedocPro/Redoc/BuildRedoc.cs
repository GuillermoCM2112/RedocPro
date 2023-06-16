﻿using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Writers;
using RedocPro.Environments;
using Swashbuckle.AspNetCore.Swagger;

namespace RedocPro.Redoc
{
	public static class BuildRedoc
    {
        private static void GenerateSwagger(WebApplication app, ApiVersionDescription desc, string filePath = "../swagger_files/swagger#VER#.json")
        {
            var stringWriter = new StringWriter();
            filePath = filePath.Replace("#VER#", desc.GroupName);
            app.Services.GetRequiredService<ISwaggerProvider>().GetSwagger(desc.GroupName).SerializeAsV3(new OpenApiJsonWriter(stringWriter));
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            File.WriteAllText(filePath, stringWriter.ToString());
        }

        private static void GenerateEnvironmentPostman(string filePath = "../test_environment.json")
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            File.WriteAllText(filePath, TestEnvironment.GenerateTestEnvironment());
        }

        public static void GenerateResources(WebApplication app, IApiVersionDescriptionProvider versions)
        {
            foreach (var description in versions.ApiVersionDescriptions)
            {
                GenerateSwagger(app, description);
            }

            GenerateEnvironmentPostman();
        }

        public static void GenerateSwaggerEndpoint(WebApplication app, IReadOnlyList<ApiVersionDescription> versions)
        {
			string urlVersions = string.Empty;
			app.UseSwaggerUI(options =>
            {
                foreach (var description in versions)
                {
                    app.UseSwagger();
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);

                    app.UseReDoc(options =>
                    {
                        options.DocumentTitle = $"CIAM Demo Documentation {description.GroupName}";
                        options.RoutePrefix = $"api-docs-{description.GroupName}";
                        options.HideDownloadButton();
                        options.ExpandResponses(description.GroupName == "v1" ? "200" : string.Empty);
                        urlVersions += string.Format("* [{0}]({1}{0})\n", description.GroupName, "https://guillermocm2112.github.io/RedocPro/swagger");
                    });
                }
            });

            GenerateApiVersionsMarkdown(urlVersions);
        }

		public static void GenerateApiVersionsMarkdown(string urlVersions)
		{
			var filePath = "../docs/04 Versions.md";
			if (!File.Exists(filePath))
			{
				File.Create(filePath).Close();
			}
            string content = string.Format("# API Versions \n{0} ", urlVersions);
			File.WriteAllText(filePath, content);
		}
	}
}
