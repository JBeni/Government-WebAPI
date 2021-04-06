using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.MedicalPayments.Commands;
using GovernmentSystem.Application.Handlers.MedicalPayments.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalPaymentService
    {
        Task<RequestResponse> CreateMedicalPayment(CreateMedicalPaymentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalPayment(DeleteMedicalPaymentCommand command, CancellationToken cancellationToken);
        MedicalPaymentResponse GetMedicalPaymentById(GetMedicalPaymentByIdQuery query);
        List<MedicalPaymentResponse> GetMedicalPayments(GetMedicalPaymentsQuery query);
        Task<RequestResponse> UpdateMedicalPayment(UpdateMedicalPaymentCommand command, CancellationToken cancellationToken);
    }
}
