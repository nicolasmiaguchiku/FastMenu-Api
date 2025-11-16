using FoodManager.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace FoodManager.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity>(IMongoDatabase mongoDb, string collectionName) : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection = mongoDb.GetCollection<TEntity>(collectionName);

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
             await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }

        public async Task<long> DeleteAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken)
        {
            var result = await _collection.DeleteOneAsync(filterExpression, cancellationToken: cancellationToken);

            return result.DeletedCount;
        }
    }
}