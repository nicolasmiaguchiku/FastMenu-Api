using LiteBus.Commands.Abstractions;
using Microsoft.AspNetCore.Http;

namespace FoodManager.Application.Input.Handlers.Commands;

public sealed record UploadImageFoodCommand(IFormFile File) : ICommand<string>;