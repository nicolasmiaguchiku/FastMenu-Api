using FoodManager.Application.Input.Requests;
using FoodManager.Application.Output.Response;
using FoodManager.Domain.Filters;
using FoodManager.Domain.Results;
using LiteBus.Queries.Abstractions;

namespace FoodManager.Application.Output.Queries;
public sealed record GetFoodQuery(GetFoodRequest Foodequest) : IQuery<Result<PagedResult<GetFoodResponse>>>;

