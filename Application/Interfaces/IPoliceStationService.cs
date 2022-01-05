namespace GovernmentSystem.Application.Interfaces
{
    public interface IPoliceStationService
    {
        Task<RequestResponse> CreatePoliceStation(CreatePoliceStationCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePoliceStation(DeletePoliceStationCommand command, CancellationToken cancellationToken);
        PoliceStationResponse GetPoliceStationById(GetPoliceStationByIdQuery query);
        List<PoliceStationResponse> GetPoliceStations(GetPoliceStationsQuery query);
        Task<RequestResponse> UpdatePoliceStation(UpdatePoliceStationCommand command, CancellationToken cancellationToken);
    }
}
