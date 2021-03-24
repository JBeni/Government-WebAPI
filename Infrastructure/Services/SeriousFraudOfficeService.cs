using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.SeriousFraudOffices.Commands;
using GovernmentSystem.Application.Handlers.SeriousFraudOffices.Queries;
using GovernmentSystem.Application.Interfaces;
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

        public SeriousFraudOfficeByIdResponse GetSeriousFraudOfficeById(GetSeriousFraudOfficeByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<SeriousFraudOfficesResponse> GetSeriousFraudOffices(GetSeriousFraudOfficesQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdateSeriousFraudOffice(UpdateSeriousFraudOfficeCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
