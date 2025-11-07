using FoodManager.Domain.Entities;
using FoodManager.Domain.Filters;

namespace FoodManager.Domain.Interfaces;

public interface IFoodRepository : IBaseRepository<FoodEntity>
{
    Task<PagedResult<FoodEntity>> GetFoodsAsync(FoodFiltersBuilder filters, CancellationToken cancellationToken);
}