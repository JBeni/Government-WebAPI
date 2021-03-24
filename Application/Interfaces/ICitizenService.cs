using GovernmentSystem.Application.Handlers.Citizens.Commands;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.Citizens.Queries;
using System.Collections.Generic;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenService
    {
        Task<RequestResponse> CreateCitizen(CreateCitizenCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizen(DeleteCitizenCommand command, CancellationToken cancellationToken);
        string GenerateCNP(DateTime dateOfBirth, string userGender);
        ExportCitizensVm ExportCitizensQuery(ExportCitizensQuery query);
        CitizenResponse GetCitizenById(GetCitizenByIdQuery query);
        List<CitizensResponse> GetCitizens(GetCitizensQuery query);
        Task<RequestResponse> UpdateCitizen(UpdateCitizenCommand command, CancellationToken cancellationToken);
    }
}
