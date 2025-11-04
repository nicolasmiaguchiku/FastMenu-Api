//using LiteBus.Queries.Abstractions;
//using Microsoft.AspNetCore.Mvc;
//using FastMenu.Application.Handlers.Queries;

//namespace FastMenu.WebApi.Controllers
//{
//    [ApiController]
//    [Route("api/v1/food")]
//    public class FoodQueriesControllers(IQueryMediator queryMediator) : ControllerBase
//    {
//        [HttpGet]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
//        public async Task<IActionResult> GetAllFoodsAsync(CancellationToken cancellationToken)
//        {
//            var result = await queryMediator.QueryAsync(new GetFoodQuery(), cancellationToken);
//            if (result.IsSuccess)
//            {
//                return Ok(result.Data);
//            }

//            return BadRequest(result.Error);
//        }
//    }
//}
