namespace GovernmentSystem.Application.Common.Interfaces
{
    public interface IUploadDocument
    {
        Task Upload(List<IFormFile> documents);
    }
}
