namespace GovernmentSystem.Application.Interfaces
{
    public interface IPoliceStationService
    {
        Task<RequestResponse> CreatePoliceStation(CreatePoliceStationCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePoliceStation(DeletePoliceStationCommand command, CancellationToken cancellationToken);
        Result<PoliceStationResponse> GetPoliceStationById(GetPoliceStationByIdQuery query);
        Result<PoliceStationResponse> GetPoliceStations(GetPoliceStationsQuery query);
        Task<RequestResponse> UpdatePoliceStation(UpdatePoliceStationCommand command, CancellationToken cancellationToken);
    }
}
