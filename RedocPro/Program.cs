using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Swagger Demo Documentation",
                    Version = "v1",
                    Description = File.ReadAllText("../README.md", Encoding.UTF8),
                    Contact = new OpenApiContact
                    {
                        Name = "test",
                        Email = "someemail@somedomain.com"
                    },
                    Extensions = new Dictionary<string, IOpenApiExtension>
                    {
                      {"x-logo", new OpenApiObject
                        {
                           {"url", new OpenApiString("https://www.femsa.com/wp-content/uploads/2022/05/digital-at-femsa-logotype-h-blk-2048x550.png")},
                           { "altText", new OpenApiString("Your logo alt text here")}
                        }
                      }
                    }
                });

            /*var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);*/


        });

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {

        }

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json",
        "Swagger Demo Documentation v1");
        });

        app.UseReDoc(options =>
        {
            options.DocumentTitle = "Swagger Demo Documentation";
            options.SpecUrl = "/swagger/v1/swagger.json";
        });

        var swaggerProvider = app.Services.GetRequiredService<ISwaggerProvider>();
        var swagger = swaggerProvider.GetSwagger("v1");
        var stringWriter = new StringWriter();
        swagger.SerializeAsV3(new OpenApiJsonWriter(stringWriter));
        var swaggerJson = stringWriter.ToString();
        var filePath = "../swagger.json";
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        File.WriteAllText(filePath, swaggerJson);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}