using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.SeriousFraudOffices.Commands;
using GovernmentSystem.Application.Handlers.SeriousFraudOffices.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class SeriousFraudOfficeService : ISeriousFraudOfficeService
    {
        public Task<RequestResponse> CreateSeriousFraudOffice(CreateSeriousFraudOfficeCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeleteSeriousFraudOffice(DeleteSeriousFraudOfficeCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public SeriousFraudOfficeResponse GetSeriousFraudOfficeById(GetSeriousFraudOfficeByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<SeriousFraudOfficeResponse> GetSeriousFraudOffices(GetSeriousFraudOfficesQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdateSeriousFraudOffice(UpdateSeriousFraudOfficeCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
