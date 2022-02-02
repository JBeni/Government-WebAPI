namespace GovernmentSystem.WebUI.Controllers
{
    public class AddressTypesController : ApiControllerBase
    {
        [HttpGet("address-type/{id}")]
        public async Task<IActionResult> GetAddressTypeById(Guid id)
        {
            var result = await Mediator.Send(new GetAddressTypeByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("address-types")]
        public async Task<IActionResult> GetAddressTypes()
        {
            var result = await Mediator.Send(new GetAddressTypesQuery { });
            return Ok(result);
        }
    }
}
