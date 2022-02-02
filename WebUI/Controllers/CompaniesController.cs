namespace GovernmentSystem.WebUI.Controllers
{
    public class CompanyController : ApiControllerBase
    {
        [HttpGet("company/{id}")]
        public async Task<IActionResult> GetCompanyById(Guid id)
        {
            var result = await Mediator.Send(new GetCompanyByIdQuery { Identifier = id });
            return Ok(result);
        }

        [HttpGet("companies")]
        public async Task<IActionResult> GetCompanies()
        {
            var result = await Mediator.Send(new GetCompaniesQuery { });
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCompanyCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCompanyCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCompanyCommand command)
        {
            var result = await Mediator.Send(command);
            return result.Successful == true ? Ok(result) : BadRequest(result);
        }
    }
}
