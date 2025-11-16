using FoodManager.Domain.Enums;

namespace FoodManager.Application.Output.Response
{
    public sealed record GetFoodResponse
    (
        Guid Id,
        string Name,
        decimal Price,
        string Description,
        int Assessment,
        Category Category
    );
}