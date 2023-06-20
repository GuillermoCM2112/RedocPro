using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

namespace RedocPro.Redoc
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly string files = string.Empty;
        private readonly string deprecatedMessage = " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
        private readonly Dictionary<string, IOpenApiExtension> extensions = new Dictionary<string, IOpenApiExtension>();
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
            this.files = GetAllFilesInDocumentation();
            this.extensions = GetExtensions();
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        private string ValidateVersion(ApiVersion apiVersion)
        => apiVersion.MajorVersion == Program.DEFAULT_VERSION && apiVersion.MinorVersion == 0 ? files : string.Empty;

        private Dictionary<string, IOpenApiExtension> GetExtensions() =>
        new()
        {
            {"x-logo", new OpenApiObject
              {
                 {"url", new OpenApiString("https://img.freepik.com/vector-premium/diseno-logotipo-agua-hexagonal-listo-usar_94202-237.jpg?w=360")},
                 { "altText", new OpenApiString("Your logo alt text here")}
              }
            }
        };

        private string GetAllFilesInDocumentation(string routeDocs = "../docs", string routeReadme = "../README.md")
        {
            string baseFiles = File.ReadAllText(routeReadme, Encoding.UTF8);
            if (Directory.Exists(routeDocs) && Directory.GetFiles(routeDocs).Any())
            {
                Directory.GetFiles(routeDocs).Select(k => baseFiles += File.ReadAllText(k, Encoding.UTF8)).ToList();
            }

            return baseFiles;
        }


        private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc) =>
        new()
        {
            Title = $"Redopro - {desc.GroupName}",
            Version = desc.GroupName.Replace('v', ' '),
            Description = desc.IsDeprecated ? deprecatedMessage : ValidateVersion(desc.ApiVersion),
            Contact = new OpenApiContact
            {
                Name = "test",
                Email = "someemail@somedomain.com"
            },
            Extensions = extensions
        };

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
                options.SchemaFilter<SwaggerSchemaExampleFilter>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.EnableAnnotations();
            }
        }
    }
}
