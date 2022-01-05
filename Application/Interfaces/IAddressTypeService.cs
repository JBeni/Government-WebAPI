namespace GovernmentSystem.Application.Interfaces
{
    public interface IAddressTypeService
    {
        AddressTypeResponse GetAddressTypeById(GetAddressTypeByIdQuery query);
        List<AddressTypeResponse> GetAddressTypes(GetAddressTypesQuery query);
    }
}
