namespace GovernmentSystem.WebUI.Controllers
{
    public class PublicServantPolicesController : ApiControllerBase
    {
        [HttpGet("public-servant-police/{id}")]
        public async Task<IActionResult> GetPublicServantPoliceStationById(Guid id)
        {
            var result = await Mediator.Send(new GetPublicServantPoliceStationByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("public-servant-polices")]
        public async Task<IActionResult> GetPublicServantPoliceStations()
        {
            var result = await Mediator.Send(new GetPublicServantPoliceStationsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePublicServantPoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePublicServantPoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePublicServantPoliceStationCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
