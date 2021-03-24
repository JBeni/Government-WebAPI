using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Commands;
using GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Queries;
using GovernmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalCenterProcedureService : IMedicalCenterProcedureService
    {
        public Task<RequestResponse> CreateMedicalCenterProcedure(CreateMedicalCenterProcedureCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeleteMedicalCenterProcedure(DeleteMedicalCenterProcedureCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public MedicalCenterProcedureResponse GetMedicalCenterProcedureById(GetMedicalCenterProcedureByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<MedicalCenterProceduresResponse> GetMedicalCenterProcedures(GetMedicalCenterProceduresQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdateMedicalCenterProcedure(UpdateMedicalCenterProcedureCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
