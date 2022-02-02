namespace GovernmentSystem.WebUI.Controllers
{
    public class SeriousFraudOfficesController : ApiControllerBase
    {
        [HttpGet("serious-fraud-office/{id}")]
        public async Task<IActionResult> GetSeriousFraudOfficeById(Guid id)
        {
            var result = await Mediator.Send(new GetSeriousFraudOfficeByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("serious-fraud-offices")]
        public async Task<IActionResult> GetSeriousFraudOffices()
        {
            var result = await Mediator.Send(new GetSeriousFraudOfficesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
