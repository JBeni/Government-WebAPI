using GovernmentSystem.Application.Handlers.Properties.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using GovernmentSystem.Application.Handlers.Properties.Queries;
using GovernmentSystem.Application.Responses;

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
