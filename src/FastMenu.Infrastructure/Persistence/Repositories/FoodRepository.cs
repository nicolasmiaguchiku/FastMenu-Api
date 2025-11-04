using FastMenu.Domain.Dtos.Requests;
using FastMenu.Domain.Dtos.Response;
using FastMenu.Domain.Entities;
using FastMenu.Domain.Filters;
using FastMenu.Domain.Interfaces;
using FastMenu.Domain.Results;
using FastMenu.Infrastructure.Mappers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace FastMenu.Infrastructure.Persistence.Repositories
{
    public class FoodRepository(IMongoDatabase mongoDb) : IFoodRepository
    {
        private readonly IMongoCollection<FoodEntity> _collection = mongoDb.GetCollection<FoodEntity>("Foods");

        public async Task<Result<FoodResponse>> AddFoodAsync(FoodRequest foodRequest, CancellationToken cancellationToken)
        {
            var foodEntity = foodRequest.ToEntity();

            await _collection.InsertOneAsync(foodEntity, cancellationToken: cancellationToken);

            var response = foodEntity.ToResponse();

            return Result<FoodResponse>.Success(response);
        }

        public async Task<Result<IEnumerable<FoodResponse>>> GetFoodAlldAsync(FoodFilters filters, CancellationToken cancellationToken)
        {
            var pipelineDefinition = PipelineDefinitionBuilder.For<FoodEntity>().As<FoodEntity, FoodEntity, BsonDocument>();

            var options = new AggregateOptions { AllowDiskUse = true };
            var aggregation = await _collection.AggregateAsync(pipelineDefinition, options, cancellationToken);

            var bsonDocuments = await aggregation.ToListAsync();

            var foods = bsonDocuments
                .Select(bsonDocument => BsonSerializer.Deserialize<FoodEntity>(bsonDocument).ToResponse())
                .ToList();

            return Result<IEnumerable<FoodResponse>>.Success(foods);
        }
    }
}
