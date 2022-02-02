namespace GovernmentSystem.WebUI.Controllers
{
    public class PoliceStationsController : ApiControllerBase
    {
        [HttpGet("police-station/{id}")]
        public async Task<IActionResult> GetPoliceStationById(Guid id)
        {
            var result = await Mediator.Send(new GetPoliceStationByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("police-stations")]
        public async Task<IActionResult> GetPoliceStations()
        {
            var result = await Mediator.Send(new GetPoliceStationsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
