using FoodManager.Domain.Enums;

namespace FoodManager.Domain.Filters
{
    public sealed class FoodFiltersBuilder : PaginationFilter
    {
        public IEnumerable<string>? Names { get; private set; }
        public IEnumerable<Category>? Categorys { get; private set; }
        public IEnumerable<int>? Assessment { get; private set; }
        public IEnumerable<Guid>? FoodIds { get; private set; }

        private FoodFiltersBuilder() { }

        public sealed class Builder
        {
            private readonly FoodFiltersBuilder _filters = new();

            public Builder WithNames(IEnumerable<string>? names)
            {
                _filters.Names = names;
                return this;
            }

            public Builder WithCategorys(IEnumerable<Category>? categorys)
            {
                _filters.Categorys = categorys;
                return this;
            }

            public Builder WithFoodIds(IEnumerable<Guid>? foodIds)
            {
                _filters.FoodIds = foodIds;
                return this;
            }

            public Builder WithAssessment(IEnumerable<int>? assessment)
            {
                _filters.Assessment = assessment;
                return this;
            }

            public FoodFiltersBuilder Build() => _filters;
        }
    }
}
