namespace GovernmentSystem.WebUI.Controllers
{
    public class InvoicesController : ApiControllerBase
    {
        [HttpGet("invoice/{id}")]
        public async Task<IActionResult> GetInvoiceById(Guid id)
        {
            var result = await Mediator.Send(new GetInvoiceByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var result = await Mediator.Send(new GetInvoicesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteInvoiceCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
