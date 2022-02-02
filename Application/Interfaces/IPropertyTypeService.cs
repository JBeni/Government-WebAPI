namespace GovernmentSystem.Application.Interfaces
{
    public interface IPropertyTypeService
    {
        Result<PropertyTypeResponse> GetPropertyTypeById(GetPropertyTypeByIdQuery query);
        Result<PropertyTypeResponse> GetPropertyTypes(GetPropertyTypesQuery query);
    }
}
