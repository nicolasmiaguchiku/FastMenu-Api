using LiteBus.Commands.Abstractions;

namespace FoodManager.Application.Input.Handlers.Commands
{
    public sealed class UploadImageFoodCommandHandler : ICommandHandler<UploadImageFoodCommand, string>
    {
        public Task<string> HandleAsync(UploadImageFoodCommand message, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}