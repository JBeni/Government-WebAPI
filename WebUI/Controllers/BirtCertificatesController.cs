namespace GovernmentSystem.WebUI.Controllers
{
    public class BirthCertificatesController : ApiControllerBase
    {
        [HttpGet("birth-certificate/{id}")]
        public async Task<IActionResult> GetBirthCertificateById(Guid id)
        {
            var result = await Mediator.Send(new GetBirthCertificateByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("birth-certificates")]
        public async Task<IActionResult> GetBirthCertificates()
        {
            var result = await Mediator.Send(new GetBirthCertificatesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateBirthCertificateCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateBirthCertificateCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteBirthCertificateCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
