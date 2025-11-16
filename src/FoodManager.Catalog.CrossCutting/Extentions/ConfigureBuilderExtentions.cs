using FoodManager.CrossCutting.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace FoodManager.CrossCutting.Extentions
{
    public static class ConfigureBuilderExtentions
    {
        public static Settings GetApplicationSettings(this IConfiguration configuration, IHostEnvironment env)
        {
            var settings = configuration.GetSection("Settings").Get<Settings>();

            if (!env.IsDevelopment())
            {
                settings!.MongoSettings.ConnectionString = GetEnvironmentVariableValue("ConnectionString_Mongo", settings.MongoSettings.ConnectionString);
            }

            return settings!;
        }

        private static string GetEnvironmentVariableValue(string key, string? fallback)
        {
            var value = Environment.GetEnvironmentVariable(key);
            return string.IsNullOrWhiteSpace(value) ? fallback ?? "" : value;
        }
    }
}