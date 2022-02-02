namespace GovernmentSystem.WebUI.Controllers
{
    public class DocumentsController : ApiControllerBase
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
