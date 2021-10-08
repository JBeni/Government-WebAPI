using GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Commands;
using GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class PublicServantPolicesController : ApiControllerBase
    {
        [HttpGet("public-servant-police")]
        public async Task<IActionResult> GetPublicServantPoliceStationById([FromQuery] GetPublicServantPoliceStationByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("public-servant-polices")]
        public async Task<IActionResult> GetPublicServantPoliceStations([FromQuery] GetPublicServantPoliceStationsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePublicServantPoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePublicServantPoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePublicServantPoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
