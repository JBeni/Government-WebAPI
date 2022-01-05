namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalCenterService
    {
        Task<RequestResponse> CreateMedicalCenter(CreateMedicalCenterCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalCenter(DeleteMedicalCenterCommand command, CancellationToken cancellationToken);
        MedicalCenterResponse GetMedicalCenterById(GetMedicalCenterByIdQuery query);
        List<MedicalCenterResponse> GetMedicalCenters(GetMedicalCentersQuery query);
        Task<RequestResponse> UpdateMedicalCenter(UpdateMedicalCenterCommand command, CancellationToken cancellationToken);
    }
}
