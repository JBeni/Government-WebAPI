namespace GovernmentSystem.Application.Interfaces
{
    public interface IAddressTypeService
    {
        Result<AddressTypeResponse> GetAddressTypeById(GetAddressTypeByIdQuery query);
        Result<AddressTypeResponse> GetAddressTypes(GetAddressTypesQuery query);
    }
}
