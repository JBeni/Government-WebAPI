using GovernmentSystem.Application.Handlers.AddressTypes.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IAddressTypeService
    {
        AddressTypeResponse GetAddressTypeById(GetAddressTypeByIdQuery query);
        List<AddressTypeResponse> GetAddressTypes(GetAddressTypesQuery query);
    }
}
