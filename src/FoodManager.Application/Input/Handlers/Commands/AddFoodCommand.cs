using FoodManager.Application.Output.Response;
using FoodManager.Domain.Dtos.Requests;
using FoodManager.Domain.Results;
using LiteBus.Commands.Abstractions;

namespace FoodManager.Application.Input.Handlers.Commands;
public record AddFoodCommand(FoodRequest FoodRequest) : ICommand<Result<GetFoodResponse>>;
