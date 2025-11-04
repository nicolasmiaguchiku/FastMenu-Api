using FastMenu.Domain.Enums;

namespace FastMenu.Domain.Dtos.Requests
{
   public sealed record FoodRequest
   (
       string Name,
       decimal Price,
       string Description,
       int Assessment,
       Category Category
   );
}
