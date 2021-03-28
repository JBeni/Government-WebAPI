using GovernmentSystem.Application.Handlers.PublicServantCityHalls.Commands;
using GovernmentSystem.Application.Handlers.PublicServantCityHalls.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class PublicServantCityHallsController : ApiControllerBase
    {
        [HttpGet("getPublicServantCityHallById")]
        public async Task<IActionResult> GetPublicServantCityHallById([FromQuery] GetPublicServantCityHallByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getPublicServantCityHalls")]
        public async Task<IActionResult> GetPublicServantCityHalls([FromQuery] GetPublicServantCityHallsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePublicServantCityHallCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePublicServantCityHallCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(DeletePublicServantCityHallCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
