namespace GovernmentSystem.Application.Interfaces
{
    public interface IBirthCertificateService
    {
        Task<RequestResponse> CreateBirthCertificate(CreateBirthCertificateCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteBirthCertificate(DeleteBirthCertificateCommand command, CancellationToken cancellationToken);
        Result<BirthCertificateResponse> GetBirthCertificateById(GetBirthCertificateByIdQuery query);
        Result<BirthCertificateResponse> GetBirthCertificates(GetBirthCertificatesQuery query);
        Task<RequestResponse> UpdateBirthCertificate(UpdateBirthCertificateCommand command, CancellationToken cancellationToken);
    }
}
