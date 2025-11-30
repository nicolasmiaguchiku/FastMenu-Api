using FoodManager.Catalog.Catalog.Domain.Results;
using FoodManager.Catalog.Domain.Interfaces.Repositories;
using LiteBus.Commands.Abstractions;
using Microsoft.Extensions.Logging;

namespace FoodManager.Catalog.Application.Input.Handlers.Commands
{
    public sealed class DeleteFoodCommandHandler(IFoodRepository _repository, ILogger<DeleteFoodCommandHandler> _logger) : ICommandHandler<DeleteFoodCommand>
    {
        public async Task HandleAsync(DeleteFoodCommand message, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("FoodId {FoodName} deleted successfully", message.Id);
            await _repository.DeleteAsync(x => x.Id == message.Id, cancellationToken);
        }
    }
}