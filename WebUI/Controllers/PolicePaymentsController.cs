namespace GovernmentSystem.WebUI.Controllers
{
    public class PolicePaymentsController : ApiControllerBase
    {
        [HttpGet("police-payment/{id}")]
        public async Task<IActionResult> GetPolicePaymentById(Guid id)
        {
            var result = await Mediator.Send(new GetPolicePaymentByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("police-payments")]
        public async Task<IActionResult> GetPolicePayments()
        {
            var result = await Mediator.Send(new GetPolicePaymentsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePolicePaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePolicePaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePolicePaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
