namespace GovernmentSystem.WebUI.Controllers
{
    public class CitizenDriverLicenseCategoriesController : ApiControllerBase
    {
        [HttpGet("citizen-driver-license-category/{id}")]
        public async Task<IActionResult> GetCitizenDriverLicenseCategoryById(Guid id)
        {
            var result = await Mediator.Send(new GetCitizenDriverLicenseCategoryByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("citizen-driver-license-categories")]
        public async Task<IActionResult> GetCitizenDriverLicenseCategories()
        {
            var result = await Mediator.Send(new GetCitizenDriverLicenseCategoriesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCitizenDriverLicenseCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCitizenDriverLicenseCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCitizenDriverLicenseCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
