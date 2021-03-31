using GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Commands;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCitizenDriverLicenseCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCitizenDriverLicenseCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(DeleteCitizenDriverLicenseCategoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
