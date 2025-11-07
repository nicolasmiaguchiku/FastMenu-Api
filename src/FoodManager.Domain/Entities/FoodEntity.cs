using FoodManager.Domain.Enums;
using System.Net.Http.Headers;

namespace FoodManager.Domain.Entities
{
    public class FoodEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Assessment { get; set; }
        public Category Category { get; set; }

        public FoodEntity SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public FoodEntity SetName(string name)
        {
            Name = name;
            return this;
        }

        public FoodEntity SetPrice(decimal price)
        {
            Price = price;
            return this;
        }

        public FoodEntity SetDescription(string description)
        {
            Description = description;
            return this;
        }

        public FoodEntity SetAssessment(int assessment)
        {
            Assessment = assessment;
            return this;
        }

        public FoodEntity SetCategory(Category category)
        {
            Category = category;
            return this;
        }

        public Builder ToBuilder()
        {
            return new Builder
            {
                Name = Name,
                Price = Price,
                Description = Description,
                Assessment = Assessment,
                Category = Category
            };
        }

        public class Builder
        {
            public Guid Id { get; set; }
            public string? Name { get; set; }
            public decimal Price { get; set; }
            public string? Description { get; set; }
            public int Assessment { get; set; }
            public Category Category { get; set; }

            public static Builder Create() => new();

            public Builder SetId(Guid id) { Id = id; return this; }
            public Builder SetName(string name) { Name = name; return this; }
            public Builder SetPrice(decimal price) { Price = price; return this; }
            public Builder SetDescription(string description) { Description = description; return this; }
            public Builder SetAssessment(int assesment) { Assessment = assesment; return this; }
            public Builder SetCategory(Category category) { Category = category; return this; }

            public FoodEntity Build()
            {
                return new FoodEntity
                {
                    Id = Id,
                    Name = Name,
                    Price = Price,
                    Description = Description,
                    Assessment = Assessment,
                    Category = Category
                };
            }
        }
    }
}