using FastMenu.Domain.Enums;

namespace FastMenu.Domain.Filters
{
    public sealed class FoodFilters : PaginationFilter
    {
        public IEnumerable<string>? Names { get; set; }
        public IEnumerable<Category>? Categorys { get; set; }
        public IEnumerable<int>? Assessment { get; set; }
        public IEnumerable<Guid>? FoodIds { get; set; }

        private FoodFilters() { }

        public sealed class Builder
        {
            private readonly FoodFilters _filter = new();

            public Builder WithNames(IEnumerable<string> names)
            {
                _filter.Names = names;
                return this;
            }

            public Builder WithCategorys(IEnumerable<Category> categorys)
            {
                _filter.Categorys = categorys;
                return this;
            }

            public Builder WithFoodIds(IEnumerable<Guid> foodIds)
            {
                _filter.FoodIds = foodIds;
                return this;
            }

            public Builder WithAssessment(IEnumerable<int> assessment)
            {
                _filter.Assessment = assessment;
                return this;
            }
        }
    }
}
