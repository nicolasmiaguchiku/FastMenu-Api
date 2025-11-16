using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using FoodManager.Application.Output.Queries;
using FoodManager.Application.Input.Requests;

namespace FoodManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/food")]
    public class FoodQueriesControllers(IQueryMediator queryMediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllFoodsAsync([FromQuery] GetFoodRequest query, CancellationToken cancellationToken)
        {
            var result = await queryMediator.QueryAsync(new GetFoodQuery(query), cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Error);
        }
    }
}