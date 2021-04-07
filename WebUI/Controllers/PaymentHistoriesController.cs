using GovernmentSystem.Application.Handlers.PaymentHistories.Commands;
using GovernmentSystem.Application.Handlers.PaymentHistories.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class PaymentHistoriesController : ApiControllerBase
    {
        [HttpGet("getPaymentHistoryById")]
        public async Task<IActionResult> GetPaymentHistoryById([FromQuery] GetPaymentHistoryByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getPaymentHistories")]
        public async Task<IActionResult> GetPaymentHistories([FromQuery] GetPaymentHistoriesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePaymentHistoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdatePaymentHistoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePaymentHistoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
