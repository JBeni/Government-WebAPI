using GovernmentSystem.Application.Handlers.PublicServantPolices.Commands;
using GovernmentSystem.Application.Handlers.PublicServantPolices.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class PublicServantPolicesController : ApiControllerBase
    {
        [HttpGet("getPublicServantPoliceById")]
        public async Task<IActionResult> GetPublicServantPoliceById([FromQuery] GetPublicServantPoliceByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getPublicServantPolices")]
        public async Task<IActionResult> GetPublicServantPolices([FromQuery] GetPublicServantPolicesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePublicServantPoliceCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePublicServantPoliceCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePublicServantPoliceCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
