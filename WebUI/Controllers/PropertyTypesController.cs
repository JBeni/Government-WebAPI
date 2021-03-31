using GovernmentSystem.Application.Handlers.PropertyTypes.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class PropertyTypesController : ApiControllerBase
    {
        [HttpGet("getPropertyTypeById")]
        public async Task<IActionResult> GetPropertyTypeById([FromQuery] GetPropertyTypeByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getPropertyTypes")]
        public async Task<IActionResult> GetPropertyTypes([FromQuery] GetPropertyTypesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
