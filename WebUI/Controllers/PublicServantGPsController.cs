namespace GovernmentSystem.WebUI.Controllers
{
    public class PublicServantMedicalCentersController : ApiControllerBase
    {
        [HttpGet("public-servant-medical-center")]
        public async Task<IActionResult> GetPublicServantMedicalCenterById([FromQuery] GetPublicServantMedicalCenterByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("public-servant-medical-centers")]
        public async Task<IActionResult> GetPublicServantMedicalCenters([FromQuery] GetPublicServantMedicalCentersQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePublicServantMedicalCenterCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePublicServantMedicalCenterCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePublicServantMedicalCenterCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
