namespace GovernmentSystem.WebUI.Controllers
{
    public class DriverLicenseCategoriesController : ApiControllerBase
    {
        [HttpGet("driver-license-category/{id}")]
        public async Task<IActionResult> GetDriverLicenseCategoryById(Guid id)
        {
            var result = await Mediator.Send(new GetDriverLicenseCategoryByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("driver-license-categories")]
        public async Task<IActionResult> GetDriverLicenseCategories()
        {
            var result = await Mediator.Send(new GetDriverLicenseCategoriesQuery { });
            return Ok(result);
        }
    }
}
