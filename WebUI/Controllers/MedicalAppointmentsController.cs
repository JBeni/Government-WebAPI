namespace GovernmentSystem.WebUI.Controllers
{
    public class MedicalAppointmentsController : ApiControllerBase
    {
        [HttpGet("medical-appointment/{id}")]
        public async Task<IActionResult> GetMedicalAppointmentById(Guid id)
        {
            var result = await Mediator.Send(new GetMedicalAppointmentByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("medical-appointments")]
        public async Task<IActionResult> GetMedicalAppointments()
        {
            var result = await Mediator.Send(new GetMedicalAppointmentsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateMedicalAppointmentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateMedicalAppointmentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteMedicalAppointmentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
