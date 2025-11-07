using FoodManager.CrossCutting.Extentions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration
    .AddJsonFile("appsettings.json", false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{enviroment}.json", true, reloadOnChange: true)
    .AddEnvironmentVariables();

var applicationSettings = builder.Configuration.GetApplicationSettings(builder.Environment);

builder.Services
    .AddMemoryCache()
    .AddMongo(applicationSettings.MongoSettings)
    .AddServices()
    .ConfigureLiteBus()
    .AddOpenApi("v1").AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options => options.Servers = []);

app.UseHttpsRedirection()
    .UseAuthorization();

app.MapControllers();

await app.RunAsync();
