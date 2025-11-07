using FoodManager.Application.Input.Handlers.Commands;
using FoodManager.Domain.Dtos.Requests;
using LiteBus.Commands.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/food")]
    public class FoodCommandController(ICommandMediator commandMediator) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddFoodAsync([FromBody] FoodRequest request, CancellationToken cancellationToken)
        {
            var result = await commandMediator.SendAsync(new AddFoodCommand(request), cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Error);
        }
    }
}
