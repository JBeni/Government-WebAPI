namespace GovernmentSystem.WebUI.Controllers
{
    public class IdentityCardsController : ApiControllerBase
    {
        [HttpGet("identity-card/{id}")]
        public async Task<IActionResult> GetIdentityCardById(Guid id)
        {
            var result = await Mediator.Send(new GetIdentityCardByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("identity-cards")]
        public async Task<IActionResult> GetIdentityCards()
        {
            var result = await Mediator.Send(new GetIdentityCardsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateIdentityCardCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateIdentityCardCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteIdentityCardCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
