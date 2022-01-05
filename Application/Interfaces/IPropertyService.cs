namespace GovernmentSystem.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<RequestResponse> CreateProperty(CreatePropertyCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteProperty(DeletePropertyCommand command, CancellationToken cancellationToken);
        PropertyResponse GetPropertyById(GetPropertyByIdQuery query);
        List<PropertyResponse> GetProperties(GetPropertiesQuery query);
        Task<RequestResponse> UpdateProperty(UpdatePropertyCommand command, CancellationToken cancellationToken);
    }
}
