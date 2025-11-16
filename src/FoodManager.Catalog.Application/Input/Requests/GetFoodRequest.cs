using FoodManager.Domain.Enums;
using FoodManager.Domain.Filters;

namespace FoodManager.Application.Input.Requests
{
    public record GetFoodRequest
    {
        public IEnumerable<Guid>? Ids { get; set; }
        public IEnumerable<string>? Names { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<int>? Assessment { get; set; }
        public PageFilterRequest PageFilter { get; set; }

        public GetFoodRequest()
        {
            PageFilter = new PageFilterRequest
            {
                Page = 1,
                PageSize = 60
            };
        }
    }
}