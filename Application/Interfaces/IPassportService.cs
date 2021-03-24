using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.Passports.Commands;
using GovernmentSystem.Application.Handlers.Passports.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPassportService
    {
        Task<RequestResponse> CreatePassport(CreatePassportCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePassport(DeletePassportCommand command, CancellationToken cancellationToken);
        PassportResponse GetPassportById(GetPassportByIdQuery query);
        List<PassportsResponse> GetPassports(GetPassportsQuery query);
        Task<RequestResponse> UpdatePassport(UpdatePassportCommand command, CancellationToken cancellationToken);
    }
}
