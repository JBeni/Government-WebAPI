using GovernmentSystem.Application.Handlers.PropertyTypes.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPropertyTypeService
    {
        PropertyTypeResponse GetPropertyTypeById(GetPropertyTypeByIdQuery query);
        List<PropertyTypeResponse> GetPropertyTypes(GetPropertyTypesQuery query);
    }
}
