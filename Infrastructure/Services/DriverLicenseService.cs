using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.DriverLicenses.Commands;
using GovernmentSystem.Application.Handlers.DriverLicenses.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class DriverLicenseService : IDriverLicenseService
    {
        public Task<RequestResponse> CreateDriverLicense(CreateDriverLicenseCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeleteDriverLicense(DeleteDriverLicenseCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public DriverLicenseResponse GetDriverLicenseById(GetDriverLicenseByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<DriverLicenseResponse> GetDriverLicenses(GetDriverLicensesQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdateDriverLicense(UpdateDriverLicenseCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
