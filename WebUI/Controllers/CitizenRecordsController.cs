namespace GovernmentSystem.WebUI.Controllers
{
    public class CitizenRecordsController : ApiControllerBase
    {
        [HttpGet("citizen-record/{id}")]
        public async Task<IActionResult> GetCitizenRecordById(Guid id)
        {
            var result = await Mediator.Send(new GetCitizenRecordByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("citizen-records")]
        public async Task<IActionResult> GetCitizenRecords()
        {
            var result = await Mediator.Send(new GetCitizenRecordsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCitizenRecordCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCitizenRecordCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCitizenRecordCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
