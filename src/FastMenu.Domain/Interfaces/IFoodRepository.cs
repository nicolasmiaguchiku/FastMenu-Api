using FastMenu.Domain.Entities;
using FastMenu.Domain.Filters;

namespace FastMenu.Domain.Interfaces;

public interface IFoodRepository : IBaseRepository<FoodEntity>
{
    Task<PagedResult<FoodEntity>> GetFoodsAsync(FoodFiltersBuilder filters, CancellationToken cancellationToken);
}