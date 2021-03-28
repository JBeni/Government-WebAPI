using GovernmentSystem.Application.Handlers.CitizenRequests.Commands;
using GovernmentSystem.Application.Handlers.CitizenRequests.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class CitizenRequestsController : ApiControllerBase
    {
        [HttpGet("getCitizenRequestById")]
        public async Task<IActionResult> GetCitizenRequestById([FromQuery] GetCitizenRequestByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getCitizenRequests")]
        public async Task<IActionResult> GetCitizenRequests([FromQuery] GetCitizenRequestsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCitizenRequestCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCitizenRequestCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(DeleteCitizenRequestCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
