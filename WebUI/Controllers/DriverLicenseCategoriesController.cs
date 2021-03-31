using GovernmentSystem.Application.Handlers.DriverLicenseCategory.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class DriverLicenseCategoriesController : ApiControllerBase
    {
        [HttpGet("getDriverLicenseCategoryById")]
        public async Task<IActionResult> GetDriverLicenseCategoryById([FromQuery] GetDriverLicenseCategoryByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getDriverLicenseCategories")]
        public async Task<IActionResult> GetDriverLicenseCategories([FromQuery] GetDriverLicenseCategoriesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
