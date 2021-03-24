using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Commands;
using GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalCenterProcedureService
    {
        Task<RequestResponse> CreateMedicalCenterProcedure(CreateMedicalCenterProcedureCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalCenterProcedure(DeleteMedicalCenterProcedureCommand command, CancellationToken cancellationToken);
        MedicalCenterProcedureResponse GetMedicalCenterProcedureById(GetMedicalCenterProcedureByIdQuery query);
        List<MedicalCenterProceduresResponse> GetMedicalCenterProcedures(GetMedicalCenterProceduresQuery query);
        Task<RequestResponse> UpdateMedicalCenterProcedure(UpdateMedicalCenterProcedureCommand command, CancellationToken cancellationToken);
    }
}
