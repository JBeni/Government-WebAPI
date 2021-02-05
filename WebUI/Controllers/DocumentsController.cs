using GovernmentSystem.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GovernmentSystem.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IUploadDocument _uploadDocument;

        public DocumentsController(IUploadDocument uploadDocument)
        {
            _uploadDocument = uploadDocument;
        }

        [HttpPost("single-file")]
        public IActionResult Upload(List<IFormFile> files)
        {
            _uploadDocument.Upload(files);
            return Ok();
        }
    }
}
