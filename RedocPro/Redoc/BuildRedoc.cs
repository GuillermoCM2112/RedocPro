using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using RedocPro.Environments;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.XPath;

namespace RedocPro.Redoc
{
    public static class BuildRedoc
    {
        public static void GenerateSwagger(WebApplication app, string filePath = "../swagger.json")
        {
            var stringWriter = new StringWriter();
            app.Services.GetRequiredService<ISwaggerProvider>().GetSwagger("v1").SerializeAsV3(new OpenApiJsonWriter(stringWriter));
            var swaggerJson = stringWriter.ToString();
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            File.WriteAllText(filePath, swaggerJson);
        }
        public static void GenerateEnvironmentPostman()
        {
            var filePath = "../test_environment.json";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            File.WriteAllText("../test_environment.json", TestEnvironment.GenerateTestEnvironment());
        }
        public static void GenerateDocumentation(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "CIAM Demo Documentation",
                    Version = "v1",
                    Description = GetAllFilesInDocumentation(),
                    Contact = new OpenApiContact
                    {
                        Name = "test",
                        Email = "someemail@somedomain.com"
                    },
                    Extensions = new Dictionary<string, IOpenApiExtension>
                    {
                      {"x-logo", new OpenApiObject
                        {
                           {"url", new OpenApiString("https://img.freepik.com/vector-premium/diseno-logotipo-agua-hexagonal-listo-usar_94202-237.jpg?w=360")},
                           { "altText", new OpenApiString("Your logo alt text here")}
                        }
                      }
                    }
                });
            options.SchemaFilter<SwaggerSchemaExampleFilter>();
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
            options.EnableAnnotations();

        }
        public static void GenerateSwaggerEndpoint(WebApplication app)
        {
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CIAM Demo Documentation");
            });

            app.UseReDoc(options =>
            {
                options.DocumentTitle = "CIAM Demo Documentation";
                options.HideDownloadButton();
                options.ExpandResponses("200");
            });
        }


        public static string GetAllFilesInDocumentation(string routeDocs = "../docs", string routeReadme = "../README.md")
        {
            string fileBase = File.ReadAllText(routeReadme, Encoding.UTF8);
            if (Directory.Exists(routeDocs) && Directory.GetFiles(routeDocs).Any())
            {
                Directory.GetFiles(routeDocs).Select(k => fileBase += File.ReadAllText(k, Encoding.UTF8)).ToList();
            }

            return fileBase;
        }
    }
}
