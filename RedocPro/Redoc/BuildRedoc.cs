using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using RedocPro.Environments;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace RedocPro.Redoc
{
    public static class BuildRedoc
    {
        public static void GenerateSwagger(WebApplication app, ApiVersionDescription desc , string filePath = "../swaggerVER.json")
        {
            var stringWriter = new StringWriter();
            filePath = filePath.Replace("VER", desc.GroupName);
            app.Services.GetRequiredService<ISwaggerProvider>().GetSwagger(desc.GroupName).SerializeAsV3(new OpenApiJsonWriter(stringWriter));
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            File.WriteAllText(filePath, stringWriter.ToString());
        }

        public static void GenerateEnvironmentPostman(string filePath = "../test_environment.json")
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            File.WriteAllText(filePath, TestEnvironment.GenerateTestEnvironment());
        }

        public static void GenerateSwaggerEndpoint(WebApplication app, IReadOnlyList<ApiVersionDescription> versions)
        {
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
                    });
                }
            });
        }
    }
}
