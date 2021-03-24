using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.Passports.Commands;
using GovernmentSystem.Application.Handlers.Passports.Queries;
using GovernmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PassportService : IPassportService
    {
        public Task<RequestResponse> CreatePassport(CreatePassportCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeletePassport(DeletePassportCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public PassportResponse GetPassportById(GetPassportByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<PassportsResponse> GetPassports(GetPassportsQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdatePassport(UpdatePassportCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
