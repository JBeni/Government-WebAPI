using GovernmentSystem.Application.Citizens.Commands;
using GovernmentSystem.Application.Citizens.Queries;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Common.Security;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    [Authorize]
    public class CitizenController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<CitizenDto>>> GetCitizensWithPagination([FromBody] GetCitizensWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCitizenCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCitizenCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCitizenCommand { Id = id });
            return NoContent();
        }
    }
}
