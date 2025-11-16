using LiteBus.Commands.Extensions.MicrosoftDependencyInjection;
using LiteBus.Queries.Extensions.MicrosoftDependencyInjection;
using LiteBus.Messaging.Extensions.MicrosoftDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using FoodManager.Application.Output.Queries;
using FoodManager.Application.Input.Handlers.Commands;

namespace FoodManager.CrossCutting.Extentions
{
    public static class LiteBusExtentions
    {
        public static IServiceCollection ConfigureLiteBus(this IServiceCollection services)
        {
            services.AddLiteBus(litebus =>
            {
                litebus.AddCommandModule(module =>
                {
                    module.RegisterFromAssembly(typeof(AddFoodCommandHandler).Assembly);
                });

                litebus.AddQueryModule(module =>
                {
                    module.RegisterFromAssembly(typeof(GetFoodQueryHandler).Assembly);
                });
            });

            return services;
        }
    }
}