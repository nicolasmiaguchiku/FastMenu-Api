using FastMenu.Application.Input.Requests;
using FastMenu.Application.Output.Response;
using FastMenu.Domain.Filters;
using FastMenu.Domain.Results;
using LiteBus.Queries.Abstractions;

namespace FastMenu.Application.Output.Queries;
public sealed record GetFoodQuery(GetFoodRequest Foodequest) : IQuery<Result<PagedResult<GetFoodResponse>>>;

