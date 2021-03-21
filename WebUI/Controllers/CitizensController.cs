using GovernmentSystem.Application.Handlers.Citizens.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class CitizensController : ApiControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCitizenCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCitizenCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(DeleteCitizenCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
