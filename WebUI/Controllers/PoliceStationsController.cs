using GovernmentSystem.Application.Handlers.PoliceStations.Commands;
using GovernmentSystem.Application.Handlers.PoliceStations.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class PoliceStationsController : ApiControllerBase
    {
        [HttpGet("getPoliceStationById")]
        public async Task<IActionResult> GetPoliceStationById([FromQuery] GetPoliceStationByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getPoliceStations")]
        public async Task<IActionResult> GetPoliceStations([FromQuery] GetPoliceStationsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(DeletePoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
