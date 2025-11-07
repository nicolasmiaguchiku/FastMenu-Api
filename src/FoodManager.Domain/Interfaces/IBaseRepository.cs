using System.Linq.Expressions;

namespace FoodManager.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
