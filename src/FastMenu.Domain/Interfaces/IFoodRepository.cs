using FastMenu.Domain.Results;
using FastMenu.Domain.Dtos.Response;
using FastMenu.Domain.Dtos.Requests;
using FastMenu.Domain.Filters;

namespace FastMenu.Domain.Interfaces
{
    public interface IFoodRepository
    {
        Task<Result<FoodResponse>> AddFoodAsync(FoodRequest foodRequest, CancellationToken cancellationToken);
        Task<Result<IEnumerable<FoodResponse>>> GetFoodAlldAsync(FoodFilters filters, CancellationToken cancellationToken);
    }
}