namespace GovernmentSystem.WebUI.Controllers
{
    public class PropertyTypesController : ApiControllerBase
    {
        [HttpGet("property-type/{id}")]
        public async Task<IActionResult> GetPropertyTypeById(Guid id)
        {
            var result = await Mediator.Send(new GetPropertyTypeByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("property-types")]
        public async Task<IActionResult> GetPropertyTypes()
        {
            var result = await Mediator.Send(new GetPropertyTypesQuery { });
            return Ok(result);
        }
    }
}
