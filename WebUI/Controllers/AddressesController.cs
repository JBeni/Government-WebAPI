using GovernmentSystem.Application.Handlers.Addresses.Commands;
using GovernmentSystem.Application.Handlers.Addresses.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class AddressesController : ApiControllerBase
    {
        [HttpGet("getAddressById")]
        public async Task<IActionResult> GetAddressById([FromQuery] GetAddressByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getAddresses")]
        public async Task<IActionResult> GetAddresses([FromQuery] GetAddressesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateAddressCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateAddressCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(DeleteAddressCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
