namespace GovernmentSystem.WebUI.Controllers
{
    public class PublicServantCityHallsController : ApiControllerBase
    {
        [HttpGet("public-servant-cityhall/{id}")]
        public async Task<IActionResult> GetPublicServantCityHallById(Guid id)
        {
            var result = await Mediator.Send(new GetPublicServantCityHallByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("public-servant-cityhalls")]
        public async Task<IActionResult> GetPublicServantCityHalls()
        {
            var result = await Mediator.Send(new GetPublicServantCityHallsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePublicServantCityHallCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePublicServantCityHallCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePublicServantCityHallCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
