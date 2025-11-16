using FoodManager.Application.Input.Handlers.Commands;
using FoodManager.Application.Input.Requests;
using LiteBus.Commands.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/food")]
    public class FoodCommandController(ICommandMediator commandMediator) : ControllerBase
    {
        /// <summary>
        /// Add a new food to the platform.
        /// </summary>
        /// <returns>A status code related to the operation.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddFoodAsync([FromBody] AddFoodRequest request, CancellationToken cancellationToken)
        {
            var result = await commandMediator.SendAsync(new AddFoodCommand(request), cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Error);
        }

        /// <summary>
        /// Delete a food based on id previosly informed.
        /// </summary>
        /// <returns>A status code related to the operation.</returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFoodAsync(Guid id, CancellationToken cancellationToken)
        {
            await commandMediator.SendAsync(new DeleteFoodCommand(id), cancellationToken);
            return NoContent();
        }
    }
}