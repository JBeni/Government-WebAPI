using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Commands;
using GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenMedicalHistoryService
    {
        Task<RequestResponse> CreateCitizenMedicalHistory(CreateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenMedicalHistory(DeleteCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
        CitizenMedicalHistoryResponse GetCitizenMedicalHistoryById(GetCitizenMedicalHistoryByIdQuery query);
        List<CitizenMedicalHistoryResponse> GetCitizenMedicalHistories(GetCitizenMedicalHistoriesQuery query);
        Task<RequestResponse> UpdateCitizenMedicalHistory(UpdateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
    }
}
