namespace GovernmentSystem.WebUI.Controllers
{
    public class PoliceReportProblemsController : ApiControllerBase
    {
        [HttpGet("police-report-problem/{id}")]
        public async Task<IActionResult> GetPoliceReportProblemById(Guid id)
        {
            var result = await Mediator.Send(new GetPoliceReportProblemByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("police-report-problems")]
        public async Task<IActionResult> GetPoliceReportProblems()
        {
            var result = await Mediator.Send(new GetPoliceReportProblemsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePoliceReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePoliceReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePoliceReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
