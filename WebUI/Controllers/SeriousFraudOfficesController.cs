namespace GovernmentSystem.WebUI.Controllers
{
    public class SeriousFraudOfficesController : ApiControllerBase
    {
        [HttpGet("serious-fraud-office")]
        public async Task<IActionResult> GetSeriousFraudOfficeById([FromQuery] GetSeriousFraudOfficeByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("serious-fraud-offices")]
        public async Task<IActionResult> GetSeriousFraudOffices([FromQuery] GetSeriousFraudOfficesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
