namespace GovernmentSystem.WebUI.Controllers
{
    public class RegularizationsController : ApiControllerBase
    {
        [HttpGet("regularization/{id}")]
        public async Task<IActionResult> GetRegularizationById(Guid id)
        {
            var result = await Mediator.Send(new GetRegularizationByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("regularizations")]
        public async Task<IActionResult> GetRegularizations()
        {
            var result = await Mediator.Send(new GetRegularizationsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateRegularizationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateRegularizationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteRegularizationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
