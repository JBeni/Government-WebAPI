using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.Addresses.Commands;
using GovernmentSystem.Application.Handlers.Addresses.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IAddressService
    {
        Task<RequestResponse> CreateAddress(CreateAddressCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteAddress(DeleteAddressCommand command, CancellationToken cancellationToken);
        List<AddressesResponse> GetAddresses(GetAddressesQuery query);
        List<AddressByTypeResponse> GetAddressByType(GetAddressByTypeQuery query);
        AddressByIdResponse GetAddressById(GetAddressByIdQuery query);
        List<AddressByCountyResponse> GetAddressByCounty(GetAddressByCountyQuery query);
        Task<RequestResponse> UpdateAddress(UpdateAddressCommand command, CancellationToken cancellationToken);
    }
}
