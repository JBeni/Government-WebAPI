﻿using GovernmentSystem.Application.Handlers.MedicalPayments.Commands;
using GovernmentSystem.Application.Handlers.MedicalPayments.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class MedicalPaymentiesController : ApiControllerBase
    {
        [HttpGet("getMedicalPaymentById")]
        public async Task<IActionResult> GetMedicalPaymentById([FromQuery] GetMedicalPaymentByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getMedicalPayments")]
        public async Task<IActionResult> GetMedicalPayments([FromQuery] GetMedicalPaymentsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateMedicalPaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateMedicalPaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteMedicalPaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}
