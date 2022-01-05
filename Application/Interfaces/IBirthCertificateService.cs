namespace GovernmentSystem.Application.Interfaces
{
    public interface IBirthCertificateService
    {
        Task<RequestResponse> CreateBirthCertificate(CreateBirthCertificateCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteBirthCertificate(DeleteBirthCertificateCommand command, CancellationToken cancellationToken);
        BirthCertificateResponse GetBirthCertificateById(GetBirthCertificateByIdQuery query);
        List<BirthCertificateResponse> GetBirthCertificates(GetBirthCertificatesQuery query);
        Task<RequestResponse> UpdateBirthCertificate(UpdateBirthCertificateCommand command, CancellationToken cancellationToken);
    }
}
