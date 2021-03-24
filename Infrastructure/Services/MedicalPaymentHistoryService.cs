using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Commands;
using GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalPaymentHistoryService : IMedicalPaymentHistoryService
    {
        public Task<RequestResponse> CreateMedicalPaymentHistory(CreateMedicalPaymentHistoryCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeleteMedicalPaymentHistory(DeleteMedicalPaymentHistoryCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public List<MedicalPaymentHistoryResponse> GetMedicalPaymentHistories(GetMedicalPaymentHistoriesQuery query)
        {
            throw new NotImplementedException();
        }

        public MedicalPaymentHistoryResponse GetMedicalPaymentHistoryById(GetMedicalPaymentHistoryByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdateMedicalPaymentHistory(UpdateMedicalPaymentHistoryCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
