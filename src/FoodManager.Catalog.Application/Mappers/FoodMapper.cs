using FoodManager.Application.Input.Requests;
using FoodManager.Application.Output.Response;
using FoodManager.Domain.Entities;
using FoodManager.Domain.Filters;

namespace FoodManager.Application.Mappers
{
    public static class FoodMapper
    {
        public static FoodEntity ToEntity(this AddFoodRequest food)
        {
            return new FoodEntity
            {
                Id = Guid.NewGuid(),
                Name = food.Name,
                Price = food.Price,
                Description = food.Description,
                Assessment = food.Assessment,
                Category = food.Category,
            };
        }

        public static GetFoodResponse ToResponse(this FoodEntity entity)
        {
            var food = new GetFoodResponse(
                entity.Id,
                entity.Name ?? "",
                entity.Price,
                entity.Description ?? "",
                entity.Assessment,
                entity.Category);

            return food;
        }

        public static PagedResult<GetFoodResponse> ToResponse(
          this PagedResult<FoodEntity> pagedResult,
          PageFilterRequest pageFilterRequest)
        {
            return new PagedResult<GetFoodResponse>
            {
                PageNumber = pageFilterRequest.Page,
                PageSize = pageFilterRequest.PageSize,
                TotalPages = pagedResult.TotalPages,
                TotalResults = pagedResult.TotalResults,
                Results = pagedResult.Results.Select(result => result.ToResponse())
            };
        }

        public static IEnumerable<GetFoodResponse> ToResponse(this PagedResult<GetFoodResponse> pagedResult)
        {
            return pagedResult.Results.Select(x => x);
        }

        public static PagedResult<GetFoodResponse> ToResponse(this IEnumerable<GetFoodResponse> foods, PageFilterRequest pageFilter)
        {
            return new PagedResult<GetFoodResponse>
            {
                PageNumber = pageFilter.Page,
                PageSize = pageFilter.PageSize,
                Results = foods.Select(x => x),
                TotalPages = pageFilter.Page,
                TotalResults = foods.Count()
            };
        }
    }
}