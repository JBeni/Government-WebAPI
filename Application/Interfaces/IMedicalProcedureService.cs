using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.MedicalProcedures.Commands;
using GovernmentSystem.Application.Handlers.MedicalProcedures.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalProcedureService
    {
        Task<RequestResponse> CreateMedicalProcedure(CreateMedicalProcedureCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalProcedure(DeleteMedicalProcedureCommand command, CancellationToken cancellationToken);
        MedicalProcedureResponse GetMedicalProcedureById(GetMedicalProcedureByIdQuery query);
        List<MedicalProcedureResponse> GetMedicalProcedures(GetMedicalProceduresQuery query);
        Task<RequestResponse> UpdateMedicalProcedure(UpdateMedicalProcedureCommand command, CancellationToken cancellationToken);
    }
}
