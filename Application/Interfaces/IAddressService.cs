namespace GovernmentSystem.Application.Interfaces
{
    public interface IAddressService
    {
        Task<RequestResponse> CreateAddress(CreateAddressCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteAddress(DeleteAddressCommand command, CancellationToken cancellationToken);
        Result<AddressResponse> GetAddresses(GetAddressesQuery query);
        Result<AddressResponse> GetAddressByType(GetAddressByTypeQuery query);
        Result<AddressResponse> GetAddressById(GetAddressByIdQuery query);
        Result<AddressResponse> GetAddressByCounty(GetAddressByCountyQuery query);
        Task<RequestResponse> UpdateAddress(UpdateAddressCommand command, CancellationToken cancellationToken);
    }
}
