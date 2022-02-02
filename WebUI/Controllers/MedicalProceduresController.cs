namespace GovernmentSystem.WebUI.Controllers
{
    public class MedicalProceduresController : ApiControllerBase
    {
        [HttpGet("medical-procedure/{id}")]
        public async Task<IActionResult> GetMedicalProcedureById(Guid id)
        {
            var result = await Mediator.Send(new GetMedicalProcedureByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("medical-procedures")]
        public async Task<IActionResult> GetMedicalProcedures()
        {
            var result = await Mediator.Send(new GetMedicalProceduresQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateMedicalProcedureCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateMedicalProcedureCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteMedicalProcedureCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
