using FoodManager.Domain.Entities;
using FoodManager.Domain.Filters;

namespace FoodManager.Domain.Interfaces.Repositories;

public interface IFoodRepository : IBaseRepository<FoodEntity>
{
    Task<PagedResult<FoodEntity>> GetFoodsAsync(FoodFiltersBuilder filters, CancellationToken cancellationToken);
}