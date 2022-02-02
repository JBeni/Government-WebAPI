namespace GovernmentSystem.WebUI.Controllers
{
    public class CitizenRequestsController : ApiControllerBase
    {
        [HttpGet("citizen-request/{id}")]
        public async Task<IActionResult> GetCitizenRequestById(Guid id)
        {
            var result = await Mediator.Send(new GetCitizenRequestByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("citizen-requests")]
        public async Task<IActionResult> GetCitizenRequests()
        {
            var result = await Mediator.Send(new GetCitizenRequestsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCitizenRequestCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCitizenRequestCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCitizenRequestCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
