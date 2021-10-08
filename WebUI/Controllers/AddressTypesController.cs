using GovernmentSystem.Application.Handlers.AddressTypes.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class AddressTypesController : ApiControllerBase
    {
        [HttpGet("address-type")]
        public async Task<IActionResult> GetAddressTypeById([FromQuery] GetAddressTypeByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("address-types")]
        public async Task<IActionResult> GetAddressTypes([FromQuery] GetAddressTypesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
