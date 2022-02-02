namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantPoliceStationService
    {
        Task<RequestResponse> CreatePublicServantPoliceStation(CreatePublicServantPoliceStationCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantPoliceStation(DeletePublicServantPoliceStationCommand command, CancellationToken cancellationToken);
        Result<PublicServantPoliceStationResponse> GetPublicServantPoliceStationById(GetPublicServantPoliceStationByIdQuery query);
        Result<PublicServantPoliceStationResponse> GetPublicServantPoliceStations(GetPublicServantPoliceStationsQuery query);
        Task<RequestResponse> UpdatePublicServantPoliceStation(UpdatePublicServantPoliceStationCommand command, CancellationToken cancellationToken);
    }
}
