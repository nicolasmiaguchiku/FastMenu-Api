using FoodManager.Catalog.Application.Input.Handlers.Commands;
using FoodManager.Catalog.Application.Mappers;
using FoodManager.Catalog.Application.Output.Response;
using FoodManager.Catalog.Catalog.Domain.Results;
using FoodManager.Catalog.Domain.Filters;
using FoodManager.Catalog.Domain.Interfaces.Repositories;
using FoodManager.Catalog.Domain.Interfaces.Services;
using LiteBus.Queries.Abstractions;
using Microsoft.Extensions.Logging;

namespace FoodManager.Catalog.Application.Output.Queries
{
    public class GetFoodQueryHandler(
       IFoodRepository _repository,
       ICacheService cacheService,
       ILogger<GetFoodQueryHandler> _logger) : IQueryHandler<GetFoodQuery, Result<PagedResult<GetFoodResponse>>>
    {
        public async Task<Result<PagedResult<GetFoodResponse>>> HandleAsync(GetFoodQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"Foods_{string.Join(',', request.Foodequest.Ids ?? [])}_" +
               $"{string.Join(',', request.Foodequest.Names ?? [])}_" +
               $"{string.Join(',', request.Foodequest.Assessment ?? [])}_" +
               $"{string.Join(',', request.Foodequest.Categories ?? [])}";

            var cached = await cacheService.GetCacheValueAsync<PagedResult<GetFoodResponse>>(cacheKey);

            if (cached != null)
            {
                _logger.LogInformation("Foods retrieved from cache successfully");
                return Result<PagedResult<GetFoodResponse>>.Success(cached);
            }

            var foodFilterBuilder = new FoodFiltersBuilder.Builder()
                .WithAssessment(request.Foodequest.Assessment)
                .WithCategorys(request.Foodequest.Categories)
                .WithFoodIds(request.Foodequest.Ids)
                .WithNames(request.Foodequest.Names)
                .Build();

            var foods = await _repository.GetFoodsAsync(foodFilterBuilder, cancellationToken);

            var result = foods.ToResponse(request.Foodequest.PageFilter);

            await cacheService.SetCacheValueAsync(cacheKey, result, TimeSpan.FromDays(7));

            _logger.LogInformation("Foods retrieved from dataBase successfully");

            return Result<PagedResult<GetFoodResponse>>.Success(result);
        }
    }
}