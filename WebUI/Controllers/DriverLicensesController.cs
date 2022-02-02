namespace GovernmentSystem.WebUI.Controllers
{
    public class DriverLicensesController : ApiControllerBase
    {
        [HttpGet("driver-license/{id}")]
        public async Task<IActionResult> GetDriverLicenseById(Guid id)
        {
            var result = await Mediator.Send(new GetDriverLicenseByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("driver-licenses")]
        public async Task<IActionResult> GetDriverLicenses()
        {
            var result = await Mediator.Send(new GetDriverLicensesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateDriverLicenseCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateDriverLicenseCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteDriverLicenseCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
