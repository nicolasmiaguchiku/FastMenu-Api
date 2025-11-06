using System.Linq.Expressions;

namespace FastMenu.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
