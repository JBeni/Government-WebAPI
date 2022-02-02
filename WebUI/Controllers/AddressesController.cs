namespace GovernmentSystem.WebUI.Controllers
{
    public class AddressesController : ApiControllerBase
    {
        [HttpGet("address/{id}")]
        public async Task<IActionResult> GetAddressById(Guid id)
        {
            var result = await Mediator.Send(new GetAddressByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("addresses")]
        public async Task<IActionResult> GetAddresses()
        {
            var result = await Mediator.Send(new GetAddressesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateAddressCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateAddressCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteAddressCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
