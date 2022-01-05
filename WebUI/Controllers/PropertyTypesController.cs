namespace GovernmentSystem.WebUI.Controllers
{
    public class PropertyTypesController : ApiControllerBase
    {
        [HttpGet("property-type")]
        public async Task<IActionResult> GetPropertyTypeById([FromQuery] GetPropertyTypeByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("property-types")]
        public async Task<IActionResult> GetPropertyTypes([FromQuery] GetPropertyTypesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
