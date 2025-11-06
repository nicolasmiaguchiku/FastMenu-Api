using FastMenu.Domain.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace FastMenu.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity>(IMongoDatabase mongoDb, string collectionName) : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection = mongoDb.GetCollection<TEntity>(collectionName);

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
             await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
        }
    }
}