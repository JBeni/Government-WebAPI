namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalCenterService
    {
        Task<RequestResponse> CreateMedicalCenter(CreateMedicalCenterCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalCenter(DeleteMedicalCenterCommand command, CancellationToken cancellationToken);
        Result<MedicalCenterResponse> GetMedicalCenterById(GetMedicalCenterByIdQuery query);
        Result<MedicalCenterResponse> GetMedicalCenters(GetMedicalCentersQuery query);
        Task<RequestResponse> UpdateMedicalCenter(UpdateMedicalCenterCommand command, CancellationToken cancellationToken);
    }
}
