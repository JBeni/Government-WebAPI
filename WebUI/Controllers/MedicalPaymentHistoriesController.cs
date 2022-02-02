namespace GovernmentSystem.WebUI.Controllers
{
    public class MedicalPaymentiesController : ApiControllerBase
    {
        [HttpGet("medical-payment/{id}")]
        public async Task<IActionResult> GetMedicalPaymentById(Guid id)
        {
            var result = await Mediator.Send(new GetMedicalPaymentByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("medical-payments")]
        public async Task<IActionResult> GetMedicalPayments()
        {
            var result = await Mediator.Send(new GetMedicalPaymentsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateMedicalPaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateMedicalPaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteMedicalPaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
