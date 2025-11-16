using FoodManager.Application.Input.Requests;
using FoodManager.Application.Output.Response;
using FoodManager.Domain.Results;
using LiteBus.Commands.Abstractions;

namespace FoodManager.Application.Input.Handlers.Commands;

public record AddFoodCommand(AddFoodRequest FoodRequest) : ICommand<Result<GetFoodResponse>>;