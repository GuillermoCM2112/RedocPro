using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using RedocPro.Redoc;
using RedocPro.Service;
using RedocPro.Service.Interface;

public class Program
{
    public const int DEFAULT_VERSION = 1;
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(DEFAULT_VERSION, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new HeaderApiVersionReader("x-api-version"),
                new MediaTypeApiVersionReader("x-api-version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = false;
            options.DefaultApiVersion = new ApiVersion(DEFAULT_VERSION, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersionParameterDescription = "Do NOT modify api-version!";
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

        var app = builder.Build();
        var versions = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        if (app.Environment.IsDevelopment())
        {
            BuildRedoc.GenerateSwaggerEndpoint(app, versions.ApiVersionDescriptions);
        }

        BuildRedoc.GenerateResources(app, versions);

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}