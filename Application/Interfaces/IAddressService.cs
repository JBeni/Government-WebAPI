namespace GovernmentSystem.Application.Interfaces
{
    public interface IAddressService
    {
        Task<RequestResponse> CreateAddress(CreateAddressCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteAddress(DeleteAddressCommand command, CancellationToken cancellationToken);
        List<AddressResponse> GetAddresses(GetAddressesQuery query);
        List<AddressResponse> GetAddressByType(GetAddressByTypeQuery query);
        AddressResponse GetAddressById(GetAddressByIdQuery query);
        List<AddressResponse> GetAddressByCounty(GetAddressByCountyQuery query);
        Task<RequestResponse> UpdateAddress(UpdateAddressCommand command, CancellationToken cancellationToken);
    }
}
