using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PolicePayments.Commands;
using GovernmentSystem.Application.Handlers.PolicePayments.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPolicePaymentService
    {
        Task<RequestResponse> CreatePolicePayment(CreatePolicePaymentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePolicePayment(DeletePolicePaymentCommand command, CancellationToken cancellationToken);
        PolicePaymentResponse GetPolicePaymentById(GetPolicePaymentByIdQuery query);
        List<PolicePaymentResponse> GetPolicePayments(GetPolicePaymentsQuery query);
        Task<RequestResponse> UpdatePolicePayment(UpdatePolicePaymentCommand command, CancellationToken cancellationToken);
    }
}
