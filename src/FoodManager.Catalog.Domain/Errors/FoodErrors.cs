using FoodManager.Domain.Results;

namespace FoodManager.Domain.Errors
{
    public static class FoodErrors
    {
        public static Error ValidationError(string details) => new(
        "CustomerError.ValidationError",
        details);
    }
}
