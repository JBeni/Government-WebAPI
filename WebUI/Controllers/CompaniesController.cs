﻿using GovernmentSystem.Application.Handlers.Companies.Commands;
using GovernmentSystem.Application.Handlers.Companies.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GovernmentSystem.WebUI.Controllers
{
    public class CompanyController : ApiControllerBase
    {
        [HttpGet("getCompanyById")]
        public async Task<IActionResult> GetCompanyById([FromQuery] GetCompanyByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getCompanies")]
        public async Task<IActionResult> GetCompanies([FromQuery] GetCompaniesQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCompanyCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCompanyCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCompanyCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result.Exception.InnerException.Message ?? result.Exception.Message);
        }
    }
}