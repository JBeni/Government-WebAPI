using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Commands;
using GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenMedicalHistoryService
    {
        Task<RequestResponse> AddCitizenMedicalHistory(CreateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenMedicalHistory(DeleteCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
        List<MedicalHistoryResponse> GetCitizenMedicalHistory(GetCitizenMedicalHistoryQuery query);
        Task<RequestResponse> UpdateCitizenMedicalHistory(UpdateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
    }
}
