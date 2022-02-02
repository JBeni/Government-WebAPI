namespace GovernmentSystem.WebUI.Controllers
{
    public class CitizensController : ApiControllerBase
    {
        [HttpGet("citizen/{id}")]
        public async Task<IActionResult> GetCitizenById(Guid id)
        {
            var result = await Mediator.Send(new GetCitizenByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("citizens")]
        public async Task<IActionResult> GetCitizens()
        {
            var result = await Mediator.Send(new GetCitizensQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCitizenCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCitizenCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCitizenCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
