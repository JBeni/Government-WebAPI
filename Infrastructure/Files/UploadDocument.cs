namespace GovernmentSystem.Infrastructure.Files
{
    public class UploadDocument : IUploadDocument
    {
        private readonly IConfiguration _configuration;

        public UploadDocument(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Upload(List<IFormFile> documents)
        {
            // validate the file, scan virus, save to a file storage
            string uploads = _configuration["Documents:UploadPath"];
            foreach (IFormFile file in documents)
            {
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(uploads, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
        }
    }
}
