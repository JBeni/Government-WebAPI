using GovernmentSystem.Application.Handlers.SeriousFraudOffices.Commands;
using GovernmentSystem.Application.Handlers.SeriousFraudOffices.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class SeriousFraudOfficesController : ApiControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetSeriousFraudOfficeById([FromQuery] GetSeriousFraudOfficeByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetSeriousFraudOffices([FromQuery] GetSeriousFraudOfficesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(DeleteSeriousFraudOfficeCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
