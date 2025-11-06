using FastMenu.Domain.Interfaces;
using LiteBus.Commands.Abstractions;
using FastMenu.Domain.Results;
using FastMenu.Domain.Services;
using FastMenu.Application.Mappers;
using FastMenu.Application.Output.Response;

namespace FastMenu.Application.Input.Handlers.Commands
{
    public  class AddFoodCommandHandler(IFoodRepository foodRepository, ICacheService _cache) : ICommandHandler<AddFoodCommand, Result<GetFoodResponse>>
    {
        public async Task<Result<GetFoodResponse>> HandleAsync(AddFoodCommand request, CancellationToken cancellationToken = default)
        {
            var result = request.FoodRequest.ToEntity();

            await foodRepository.AddAsync(result, cancellationToken);

            await _cache.SetCacheValueAsync("Foods", result.ToResponse(), TimeSpan.FromDays(7));

            return Result<GetFoodResponse>.Success(result.ToResponse());
        }
    }
}