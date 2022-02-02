namespace GovernmentSystem.WebUI.Controllers
{
    public class CityHallsController : ApiControllerBase
    {
        [HttpGet("cityhall/{id}")]
        public async Task<IActionResult> GetCityHallById(Guid id)
        {
            var result = await Mediator.Send(new GetCityHallByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("cityhalls")]
        public async Task<IActionResult> GetCityHalls()
        {
            var result = await Mediator.Send(new GetCityHallsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCityHallCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCityHallCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCityHallCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
