namespace GovernmentSystem.WebUI.Controllers
{
    public class CitizenMedicalHistoriesController : ApiControllerBase
    {
        [HttpGet("citizen-medical-history/{id}")]
        public async Task<IActionResult> GetCitizenMedicalHistoryById(Guid id)
        {
            var result = await Mediator.Send(new GetCitizenMedicalHistoryByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("citizen-medical-histories")]
        public async Task<IActionResult> GetCitizenMedicalHistorys()
        {
            var result = await Mediator.Send(new GetCitizenMedicalHistoriesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCitizenMedicalHistoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCitizenMedicalHistoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCitizenMedicalHistoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
