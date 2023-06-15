using RedocPro.Redoc;


public class Program
{
    public static void Main(string[] args)
    {
        var builder
            = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(BuildRedoc.GenerateDocumentation);
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            BuildRedoc.GenerateSwaggerEndpoint(app);
        }
        BuildRedoc.GenerateSwagger(app);
        BuildRedoc.GenerateEnvironmentPostman();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}