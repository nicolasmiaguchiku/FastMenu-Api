using FluentValidation;
using FluentValidation.AspNetCore;
using FoodManager.Application.Input.Requests;
using FoodManager.Application.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace FoodManager.CrossCutting.Extentions
{
    public static class ValidationExtention
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(options =>
            {
                options.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<AddFoodRequest>, AddFoodValidator>();
            return services;
        }
    }
}