namespace GovernmentSystem.WebUI.Controllers
{
    public class MedicalCenterProceduresController : ApiControllerBase
    {
        [HttpGet("medical-center-procedure")]
        public async Task<IActionResult> GetMedicalCenterProcedureById([FromQuery] GetMedicalCenterProcedureByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("medical-center-procedures")]
        public async Task<IActionResult> GetMedicalCenterProcedures([FromQuery] GetMedicalCenterProceduresQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateMedicalCenterProcedureCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateMedicalCenterProcedureCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteMedicalCenterProcedureCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
