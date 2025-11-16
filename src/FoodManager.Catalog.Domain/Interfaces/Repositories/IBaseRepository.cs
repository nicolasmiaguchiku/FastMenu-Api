using System.Linq.Expressions;

namespace FoodManager.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task<long> DeleteAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken);
    }
}