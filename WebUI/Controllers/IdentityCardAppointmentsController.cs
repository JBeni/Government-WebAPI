﻿namespace GovernmentSystem.WebUI.Controllers
{
    public class IdentityCardAppointmentssController : ApiControllerBase
    {
        [HttpGet("identity-card-appointment")]
        public async Task<IActionResult> GetIdentityCardAppointmentById([FromQuery] GetIdentityCardAppointmentByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("identity-card-appointments")]
        public async Task<IActionResult> GetIdentityCardAppointments([FromQuery] GetIdentityCardAppointmentsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateIdentityCardAppointmentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateIdentityCardAppointmentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteIdentityCardAppointmentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
