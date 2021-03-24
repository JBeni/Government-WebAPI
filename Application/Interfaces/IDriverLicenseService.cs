using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.DriverLicenses.Commands;
using GovernmentSystem.Application.Handlers.DriverLicenses.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IDriverLicenseService
    {
        Task<RequestResponse> CreateDriverLicense(CreateDriverLicenseCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteDriverLicense(DeleteDriverLicenseCommand command, CancellationToken cancellationToken);
        DriverLicenseResponse GetDriverLicenseById(GetDriverLicenseByIdQuery query);
        List<DriverLicenseResponse> GetDriverLicenses(GetDriverLicensesQuery query);
        Task<RequestResponse> UpdateDriverLicense(UpdateDriverLicenseCommand command, CancellationToken cancellationToken);
    }
}
