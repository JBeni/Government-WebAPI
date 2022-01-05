namespace GovernmentSystem.WebUI.Controllers
{
    public class PublicServantSeriousFraudOfficesController : ApiControllerBase
    {
        [HttpGet("public-servant-serious-fraud-office")]
        public async Task<IActionResult> GetPublicServantSeriousFraudOfficeById([FromQuery] GetPublicServantSeriousFraudOfficeByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("public-servant-serious-fraud-offices")]
        public async Task<IActionResult> GetPublicServantSeriousFraudOffices([FromQuery] GetPublicServantSeriousFraudOfficesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePublicServantSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePublicServantSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePublicServantSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
