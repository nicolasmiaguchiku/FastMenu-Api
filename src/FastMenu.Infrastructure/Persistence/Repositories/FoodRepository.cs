using FastMenu.Application.Output.Response;
using FastMenu.Domain.Entities;
using FastMenu.Domain.Filters;
using FastMenu.Domain.Interfaces;
using FastMenu.Infrastructure.Stages;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FastMenu.Infrastructure.Persistence.Repositories
{
    public class FoodRepository(IMongoDatabase mongoDb) : BaseRepository<FoodEntity>(mongoDb, "Foods"), IFoodRepository
    {
        private readonly IMongoCollection<FoodEntity> _collection = mongoDb.GetCollection<FoodEntity>("Foods");

        public async Task<PagedResult<FoodEntity>> GetFoodsAsync(FoodFiltersBuilder filters, CancellationToken cancellationToken)
        {
            var pipeline = PipelineDefinitionBuilder
          .For<FoodEntity>()
          .As<FoodEntity, FoodEntity, BsonDocument>()
          .FilterFoods(filters);

            var options = new AggregateOptions { AllowDiskUse = true };
            var aggregation = await _collection.AggregateAsync(pipeline, options, cancellationToken);

            var bsonDocuments = await aggregation.ToListAsync(cancellationToken);

            var foods = bsonDocuments
                .Select(bsonDocument => BsonSerializer.Deserialize<FoodEntity>(bsonDocument))
                .ToList();

            return new PagedResult<FoodEntity>
            {
                PageSize = filters.PageSize,
                Results =  foods,
                TotalResults = foods.Count
            };
        }
    }
}
