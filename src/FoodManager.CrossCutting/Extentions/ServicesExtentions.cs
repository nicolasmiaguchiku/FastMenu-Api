using FoodManager.Domain.Services;
using FoodManager.Domain.Interfaces;
using FoodManager.Infrastructure.Caching;
using FoodManager.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

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