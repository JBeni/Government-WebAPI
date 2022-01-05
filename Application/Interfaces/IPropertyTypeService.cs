namespace GovernmentSystem.Application.Interfaces
{
    public interface IPropertyTypeService
    {
        PropertyTypeResponse GetPropertyTypeById(GetPropertyTypeByIdQuery query);
        List<PropertyTypeResponse> GetPropertyTypes(GetPropertyTypesQuery query);
    }
}
