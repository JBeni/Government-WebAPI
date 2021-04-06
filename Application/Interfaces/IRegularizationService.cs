using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.Regularizations.Commands;
using GovernmentSystem.Application.Handlers.Regularizations.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IRegularizationService
    {
        Task<RequestResponse> CreateRegularization(CreateRegularizationCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteRegularization(DeleteRegularizationCommand command, CancellationToken cancellationToken);
        RegularizationResponse GetRegularizationById(GetRegularizationByIdQuery query);
        List<RegularizationResponse> GetRegularizations(GetRegularizationsQuery query);
        Task<RequestResponse> UpdateRegularization(UpdateRegularizationCommand command, CancellationToken cancellationToken);
    }
}
