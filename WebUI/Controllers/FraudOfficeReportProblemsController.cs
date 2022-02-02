namespace GovernmentSystem.WebUI.Controllers
{
    public class FraudOfficeReportProblemsController : ApiControllerBase
    {
        [HttpGet("fraud-office-report-problem/{id}")]
        public async Task<IActionResult> GetFraudOfficeReportProblemById(Guid id)
        {
            var result = await Mediator.Send(new GetFraudOfficeReportProblemByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("fraud-office-report-problems")]
        public async Task<IActionResult> GetFraudOfficeReportProblems()
        {
            var result = await Mediator.Send(new GetFraudOfficeReportProblemsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateFraudOfficeReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateFraudOfficeReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteFraudOfficeReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
