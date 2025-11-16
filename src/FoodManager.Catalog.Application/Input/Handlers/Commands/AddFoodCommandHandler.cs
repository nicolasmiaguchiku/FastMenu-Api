using FluentValidation;
using FoodManager.Application.Mappers;
using FoodManager.Application.Output.Response;
using FoodManager.Domain.Errors;
using FoodManager.Domain.Interfaces.Repositories;
using FoodManager.Domain.Interfaces.Services;
using FoodManager.Domain.Results;
using LiteBus.Commands.Abstractions;
using System.Text.Json;

namespace FoodManager.Application.Input.Handlers.Commands
{
    public sealed class AddFoodCommandHandler(IFoodRepository _repository, ICacheService _cache) : ICommandHandler<AddFoodCommand, Result<GetFoodResponse>>
    {
        public async Task<Result<GetFoodResponse>> HandleAsync(AddFoodCommand request, CancellationToken cancellationToken = default)
        {
            var result = request.FoodRequest.ToEntity();

            await _repository.AddAsync(result, cancellationToken);

            await _cache.SetCacheValueAsync("Foods", result.ToResponse(), TimeSpan.FromDays(7));

            return Result<GetFoodResponse>.Success(result.ToResponse());
        }
    }
}