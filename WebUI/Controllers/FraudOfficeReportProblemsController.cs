using GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Commands;
using GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class FraudOfficeReportProblemsController : ApiControllerBase
    {
        [HttpGet("getFraudOfficeReportProblemById")]
        public async Task<IActionResult> GetFraudOfficeReportProblemById([FromQuery] GetFraudOfficeReportProblemByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getFraudOfficeReportProblems")]
        public async Task<IActionResult> GetFraudOfficeReportProblems([FromQuery] GetFraudOfficeReportProblemsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateFraudOfficeReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateFraudOfficeReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteFraudOfficeReportProblemCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
