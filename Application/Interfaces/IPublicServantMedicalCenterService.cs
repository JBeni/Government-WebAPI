namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantMedicalCenterService
    {
        Task<RequestResponse> CreatePublicServantMedicalCenter(CreatePublicServantMedicalCenterCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantMedicalCenter(DeletePublicServantMedicalCenterCommand command, CancellationToken cancellationToken);
        Result<PublicServantMedicalCenterResponse> GetPublicServantMedicalCenterById(GetPublicServantMedicalCenterByIdQuery query);
        Result<PublicServantMedicalCenterResponse> GetPublicServantMedicalCenters(GetPublicServantMedicalCentersQuery query);
        Task<RequestResponse> UpdatePublicServantMedicalCenter(UpdatePublicServantMedicalCenterCommand command, CancellationToken cancellationToken);
    }
}
