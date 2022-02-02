namespace GovernmentSystem.WebUI.Controllers
{
    public class CityPaymentsController : ApiControllerBase
    {
        [HttpGet("city-payment/{id}")]
        public async Task<IActionResult> GetCityPaymentById(Guid id)
        {
            var result = await Mediator.Send(new GetCityPaymentByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("city-payments")]
        public async Task<IActionResult> GetCityPayments()
        {
            var result = await Mediator.Send(new GetCityPaymentsQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCityPaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCityPaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCityPaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
