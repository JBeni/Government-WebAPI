namespace GovernmentSystem.WebUI.Controllers
{
    public class IdentityCardAppointmentssController : ApiControllerBase
    {
        [HttpGet("identity-card-appointment/{id}")]
        public async Task<IActionResult> GetIdentityCardAppointmentById(Guid id)
        {
            var result = await Mediator.Send(new GetIdentityCardAppointmentByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("identity-card-appointments")]
        public async Task<IActionResult> GetIdentityCardAppointments()
        {
            var result = await Mediator.Send(new GetIdentityCardAppointmentsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateIdentityCardAppointmentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateIdentityCardAppointmentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteIdentityCardAppointmentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
