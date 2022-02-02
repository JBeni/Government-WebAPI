namespace GovernmentSystem.WebUI.Controllers
{
    public class PublicServantMedicalCentersController : ApiControllerBase
    {
        [HttpGet("public-servant-medical-center/{id}")]
        public async Task<IActionResult> GetPublicServantMedicalCenterById(Guid id)
        {
            var result = await Mediator.Send(new GetPublicServantMedicalCenterByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("public-servant-medical-centers")]
        public async Task<IActionResult> GetPublicServantMedicalCenters()
        {
            var result = await Mediator.Send(new GetPublicServantMedicalCentersQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePublicServantMedicalCenterCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePublicServantMedicalCenterCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePublicServantMedicalCenterCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
