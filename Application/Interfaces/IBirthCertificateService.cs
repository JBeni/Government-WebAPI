using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.BirthCertificates.Commands;
using GovernmentSystem.Application.Handlers.BirthCertificates.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IBirthCertificateService
    {
        Task<RequestResponse> CreateBirthCertificate(CreateBirthCertificateCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteBirthCertificate(DeleteBirthCertificateCommand command, CancellationToken cancellationToken);
        BirthCertificateByIdResponse GetBirthCertificateById(GetBirthCertificateByIdQuery query);
        List<BirthCertificateResponse> GetBirthCertificates(GetBirthCertificatesQuery query);
        Task<RequestResponse> UpdateBirthCertificate(UpdateBirthCertificateCommand command, CancellationToken cancellationToken);
    }
}
