namespace GovernmentSystem.WebUI.Controllers
{
    public class MedicalCentersController : ApiControllerBase
    {
        [HttpGet("medical-center/{id}")]
        public async Task<IActionResult> GetMedicalCenterById(Guid id)
        {
            var result = await Mediator.Send(new GetMedicalCenterByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("medical-centers")]
        public async Task<IActionResult> GetMedicalCenters()
        {
            var result = await Mediator.Send(new GetMedicalCentersQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateMedicalCenterCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateMedicalCenterCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteMedicalCenterCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
