﻿namespace GovernmentSystem.WebUI.Controllers
{
    public class TaxesController : ApiControllerBase
    {
        [HttpGet("tax")]
        public async Task<IActionResult> GetTaxById([FromQuery] GetTaxByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("taxes")]
        public async Task<IActionResult> GetTaxes([FromQuery] GetTaxesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTaxCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateTaxCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteTaxCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
