using GovernmentSystem.Application.Handlers.MedicalCenters.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.MedicalCenterById.Queries;
using GovernmentSystem.Application.Handlers.MedicalCenters.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalCenterService
    {
        Task<RequestResponse> CreateMedicalCenter(CreateMedicalCenterCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalCenter(DeleteMedicalCenterCommand command, CancellationToken cancellationToken);
        MedicalCenterResponse GetMedicalCenterById(GetMedicalCenterByIdQuery query);
        List<MedicalCenterResponse> GetMedicalCenters(GetMedicalCentersQuery query);
        Task<RequestResponse> UpdateMedicalCenter(UpdateMedicalCenterCommand command, CancellationToken cancellationToken);
    }
}
