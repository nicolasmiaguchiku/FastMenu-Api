using FoodManager.Domain.Results;
using LiteBus.Commands.Abstractions;

namespace FoodManager.Application.Input.Handlers.Commands;

public sealed record DeleteFoodCommand(Guid Id) : ICommand;