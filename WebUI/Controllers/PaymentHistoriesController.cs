namespace GovernmentSystem.WebUI.Controllers
{
    public class PaymentHistoriesController : ApiControllerBase
    {
        [HttpGet("payment-history/{id}")]
        public async Task<IActionResult> GetPaymentHistoryById(Guid id)
        {
            var result = await Mediator.Send(new GetPaymentHistoryByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("payment-histories")]
        public async Task<IActionResult> GetPaymentHistories()
        {
            var result = await Mediator.Send(new GetPaymentHistoriesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePaymentHistoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePaymentHistoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePaymentHistoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
