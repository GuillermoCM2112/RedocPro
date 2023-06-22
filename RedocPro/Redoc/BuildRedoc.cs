using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Writers;
using RedocPro.Environments;
using Swashbuckle.AspNetCore.Swagger;

namespace RedocPro.Redoc
{
    public static class BuildRedoc
    {

        private static string BuildComboBox(string urlVersions, string content = "<select onchange=\"window.open(this.options[this.selectedIndex].value)\">\r\n")
        {
            foreach (var url in urlVersions.Split(','))
            {
                if (!string.IsNullOrEmpty(url))
                {
                    string[] contents = url.Split('_');
                    content += $"<option value='{contents[0]}'>{contents[1]}</option>\r\n";
                }
            }

            return content + "</select>\r\n";
        }
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
                    options.DefaultModelsExpandDepth(-1);

                    app.UseReDoc(options =>
                    {
                        options.DocumentTitle = $"CIAM Demo Documentation {description.GroupName}";
                        options.RoutePrefix = $"api-docs-{description.GroupName}";
                        options.HideDownloadButton();
                        options.ExpandResponses(description.GroupName == "v1" ? "200" : string.Empty);
                        urlVersions += $"https://guillermocm2112.github.io/RedocPro/swagger{description.GroupName}_{description.GroupName},";
                    });
                }
            });

            GenerateApiVersionsMarkdown(urlVersions);
        }

        public static void GenerateApiVersionsMarkdown(string urlVersions, string filePath = "../docs/04 Versions.md")
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            File.WriteAllText(filePath, string.Format("# API Versions \n Avaibles: {0} ", BuildComboBox(urlVersions)));
        }
    }
}
