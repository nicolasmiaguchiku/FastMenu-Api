using FoodManager.Catalog.Application.Mappers;
using FoodManager.Catalog.Application.Output.Response;
using FoodManager.Catalog.Catalog.Domain.Results;
using FoodManager.Catalog.Domain.Interfaces.Repositories;
using FoodManager.Catalog.Domain.Interfaces.Services;
using LiteBus.Commands.Abstractions;
using Microsoft.Extensions.Logging;

namespace FoodManager.Catalog.Application.Input.Handlers.Commands
{
    public sealed class AddFoodCommandHandler(IFoodRepository _repository, ICacheService _cache, ILogger<AddFoodCommandHandler> _logger) : ICommandHandler<AddFoodCommand, Result<GetFoodResponse>>
    {
        public async Task<Result<GetFoodResponse>> HandleAsync(AddFoodCommand request, CancellationToken cancellationToken = default)
        {
            var result = request.FoodRequest.ToEntity();

            await _repository.AddAsync(result, cancellationToken);

            await _cache.SetCacheValueAsync("Foods", result.ToResponse(), TimeSpan.FromDays(7));

            _logger.LogInformation("FoodName {FoodName} add successfully", result.Name);

            return Result<GetFoodResponse>.Success(result.ToResponse());
        }
    }
}