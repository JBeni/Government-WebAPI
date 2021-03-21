using GovernmentSystem.Application.Handlers.Citizens.Commands;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenService
    {
        Task<RequestResponse> AddCitizen(CreateCitizenCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizen(DeleteCitizenCommand command, CancellationToken cancellationToken);
        string GenerateCNP(DateTime dateOfBirth, string userGender);
        Task<RequestResponse> UpdateCitizen(UpdateCitizenCommand command, CancellationToken cancellationToken);
    }
}
