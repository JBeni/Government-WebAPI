using GovernmentSystem.Application.BusinessLogic.Handlers.Citizens.Commands;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.BusinessLogic.Interfaces
{
    public interface ICitizenService
    {
        Task<RequestResponse> AddCitizen(CreateCitizenCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> UpdateCitizen(UpdateCitizenCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizen(DeleteCitizenCommand command, CancellationToken cancellationToken);

        string GenerateCNP(Citizen citizen);
    }
}
