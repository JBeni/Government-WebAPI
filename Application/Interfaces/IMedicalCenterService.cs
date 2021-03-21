using GovernmentSystem.Application.Handlers.MedicalCenters.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalCenterService
    {
        Task<RequestResponse> AddMedicalCenter(CreateMedicalCenterCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalCenter(DeleteMedicalCenterCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> UpdateMedicalCenter(UpdateMedicalCenterCommand command, CancellationToken cancellationToken);
    }
}
