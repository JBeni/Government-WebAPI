namespace GovernmentSystem.WebUI.Controllers
{
    public class ReprotProblemsController : ApiControllerBase
    {
        [HttpGet("report-problem/{id}")]
        public async Task<IActionResult> GetReportProblemById(Guid id)
        {
            var result = await Mediator.Send(new GetCityReportProblemByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("report-problems")]
        public async Task<IActionResult> GetReportProblems()
        {
            var result = await Mediator.Send(new GetCityReportProblemsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCityReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCityReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCityReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
