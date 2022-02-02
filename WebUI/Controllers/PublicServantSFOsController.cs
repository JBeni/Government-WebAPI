namespace GovernmentSystem.WebUI.Controllers
{
    public class PublicServantSeriousFraudOfficesController : ApiControllerBase
    {
        [HttpGet("public-servant-serious-fraud-office/{id}")]
        public async Task<IActionResult> GetPublicServantSeriousFraudOfficeById(Guid id)
        {
            var result = await Mediator.Send(new GetPublicServantSeriousFraudOfficeByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("public-servant-serious-fraud-offices")]
        public async Task<IActionResult> GetPublicServantSeriousFraudOffices()
        {
            var result = await Mediator.Send(new GetPublicServantSeriousFraudOfficesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePublicServantSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePublicServantSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePublicServantSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
