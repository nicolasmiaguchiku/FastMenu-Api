using FluentValidation;
using FoodManager.Application.Input.Handlers.Commands;
using FoodManager.Application.Input.Requests;

namespace FoodManager.Application.Validations
{
    public class AddFoodValidator : AbstractValidator<AddFoodRequest>
    {
        public AddFoodValidator() 
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome da comida não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O nome da comida é obrigatório.")
                .MinimumLength(10)
                .WithMessage("O nome da comida deve ter no minimo 10 caracteres")
                .MaximumLength(100)
                .WithMessage("O nome da comida deve ter no maximo 100 caracteres");

            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage("O valor da comida não pode ser nulo")
                .NotEmpty()
                .WithMessage("O valor da comida é obrigatório")
                .GreaterThan(0)
                .WithMessage("O valor da comida deve ser maior que 0");

            RuleFor(x => x.Category)
                .NotNull()
                .WithMessage("A comida deve ter uma categoria valida.")
                .NotEmpty()
                .WithMessage("A comida é obrigatório ter uma catergoria.");
        }
    }
}