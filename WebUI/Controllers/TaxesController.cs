namespace GovernmentSystem.WebUI.Controllers
{
    public class TaxesController : ApiControllerBase
    {
        [HttpGet("tax/{id}")]
        public async Task<IActionResult> GetTaxById(Guid id)
        {
            var result = await Mediator.Send(new GetTaxByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("taxes")]
        public async Task<IActionResult> GetTaxes()
        {
            var result = await Mediator.Send(new GetTaxesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTaxCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateTaxCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteTaxCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
