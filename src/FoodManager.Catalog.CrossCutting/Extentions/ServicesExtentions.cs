using FoodManager.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using FoodManager.Domain.Interfaces.Services;
using FoodManager.Domain.Interfaces.Repositories;
using FoodManager.Infrastructure.Persistence.Services;

namespace FoodManager.CrossCutting.Extentions
{
    public static class ServicesExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<ICacheService, MemoryCacheService>();

            return services;
        }
    }
}