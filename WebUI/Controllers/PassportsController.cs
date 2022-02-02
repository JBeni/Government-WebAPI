namespace GovernmentSystem.WebUI.Controllers
{
    public class PassportsController : ApiControllerBase
    {
        [HttpGet("passport/{id}")]
        public async Task<IActionResult> GetPassportById(Guid id)
        {
            var result = await Mediator.Send(new GetPassportByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("passports")]
        public async Task<IActionResult> GetPassports()
        {
            var result = await Mediator.Send(new GetPassportsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePassportCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePassportCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePassportCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
