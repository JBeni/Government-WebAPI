namespace GovernmentSystem.WebUI.Controllers
{
    public class MedicalCenterProceduresController : ApiControllerBase
    {
        [HttpGet("medical-center-procedure/{id}")]
        public async Task<IActionResult> GetMedicalCenterProcedureById(Guid id)
        {
            var result = await Mediator.Send(new GetMedicalCenterProcedureByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("medical-center-procedures")]
        public async Task<IActionResult> GetMedicalCenterProcedures()
        {
            var result = await Mediator.Send(new GetMedicalCenterProceduresQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateMedicalCenterProcedureCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateMedicalCenterProcedureCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteMedicalCenterProcedureCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
