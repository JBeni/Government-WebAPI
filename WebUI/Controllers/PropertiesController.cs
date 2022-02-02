namespace GovernmentSystem.WebUI.Controllers
{
    public class PropertiesController : ApiControllerBase
    {
        [HttpGet("property/{id}")]
        public async Task<IActionResult> GetPropertyById(Guid id)
        {
            var result = await Mediator.Send(new GetPropertyByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("properties")]
        public async Task<IActionResult> GetPropertys()
        {
            var result = await Mediator.Send(new GetPropertiesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePropertyCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePropertyCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePropertyCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
