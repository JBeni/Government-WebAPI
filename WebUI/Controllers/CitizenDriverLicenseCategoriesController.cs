using GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class CitizenDriverLicenseCategoriesController : ApiControllerBase
    {
        [HttpGet("getCitizenDriverLicenseCategoryById")]
        public async Task<IActionResult> GetCitizenDriverLicenseCategoryById([FromQuery] GetCitizenDriverLicenseCategoryByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getCitizenDriverLicenseCategories")]
        public async Task<IActionResult> GetCitizenDriverLicenseCategories([FromQuery] GetCitizenDriverLicenseCategoriesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
