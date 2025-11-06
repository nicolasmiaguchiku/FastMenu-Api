using FastMenu.Application.Output.Response;
using FastMenu.Domain.Dtos.Requests;
using FastMenu.Domain.Results;
using LiteBus.Commands.Abstractions;

namespace FastMenu.Application.Input.Handlers.Commands;
public record AddFoodCommand(FoodRequest FoodRequest) : ICommand<Result<GetFoodResponse>>;
