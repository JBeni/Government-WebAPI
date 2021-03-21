using GovernmentSystem.Application.Handlers.Properties.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<RequestResponse> AddProperty(CreatePropertyCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteProperty(DeletePropertyCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> UpdateProperty(UpdatePropertyCommand command, CancellationToken cancellationToken);
    }
}
