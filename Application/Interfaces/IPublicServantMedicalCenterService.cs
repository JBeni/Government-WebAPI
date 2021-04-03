using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Commands;
using GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantMedicalCenterService
    {
        Task<RequestResponse> CreatePublicServantMedicalCenter(CreatePublicServantMedicalCenterCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantMedicalCenter(DeletePublicServantMedicalCenterCommand command, CancellationToken cancellationToken);
        PublicServantMedicalCenterResponse GetPublicServantMedicalCenterById(GetPublicServantMedicalCenterByIdQuery query);
        List<PublicServantMedicalCenterResponse> GetPublicServantMedicalCenters(GetPublicServantMedicalCentersQuery query);
        Task<RequestResponse> UpdatePublicServantMedicalCenter(UpdatePublicServantMedicalCenterCommand command, CancellationToken cancellationToken);
    }
}
