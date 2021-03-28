using GovernmentSystem.Application.Handlers.Citizens.Commands;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.Citizens.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenService
    {
        Task<RequestResponse> CreateCitizen(CreateCitizenCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizen(DeleteCitizenCommand command, CancellationToken cancellationToken);
        string GenerateCNP(DateTime dateOfBirth, string userGender);
        Task<ExportCitizensVm> ExportCitizensQuery(ExportCitizensQuery query);
        CitizenResponse GetCitizenById(GetCitizenByIdQuery query);
        List<CitizenResponse> GetCitizens(GetCitizensQuery query);
        Task<RequestResponse> UpdateCitizen(UpdateCitizenCommand command, CancellationToken cancellationToken);
    }
}
