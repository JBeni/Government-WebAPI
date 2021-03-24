using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Commands;
using GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalPaymentHistoryService
    {
        Task<RequestResponse> CreateMedicalPaymentHistory(CreateMedicalPaymentHistoryCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalPaymentHistory(DeleteMedicalPaymentHistoryCommand command, CancellationToken cancellationToken);
        MedicalPaymentHistoryResponse GetMedicalPaymentHistoryById(GetMedicalPaymentHistoryByIdQuery query);
        List<MedicalPaymentHistoriesResponse> GetMedicalPaymentHistories(GetMedicalPaymentHistoriesQuery query);
        Task<RequestResponse> UpdateMedicalPaymentHistory(UpdateMedicalPaymentHistoryCommand command, CancellationToken cancellationToken);
    }
}
