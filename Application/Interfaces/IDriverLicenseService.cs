namespace GovernmentSystem.Application.Interfaces
{
    public interface IDriverLicenseService
    {
        Task<RequestResponse> CreateDriverLicense(CreateDriverLicenseCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteDriverLicense(DeleteDriverLicenseCommand command, CancellationToken cancellationToken);
        DriverLicenseResponse GetDriverLicenseById(GetDriverLicenseByIdQuery query);
        List<DriverLicenseResponse> GetDriverLicenses(GetDriverLicensesQuery query);
        Task<RequestResponse> UpdateDriverLicense(UpdateDriverLicenseCommand command, CancellationToken cancellationToken);
    }
}
