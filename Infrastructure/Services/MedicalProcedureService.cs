using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.MedicalProcedures.Commands;
using GovernmentSystem.Application.Handlers.MedicalProcedures.Queries;
using GovernmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalProcedureService : IMedicalProcedureService
    {
        public Task<RequestResponse> CreateMedicalProcedure(CreateMedicalProcedureCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeleteMedicalProcedure(DeleteMedicalProcedureCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public MedicalProcedureResponse GetMedicalProcedureById(GetMedicalProcedureByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<MedicalProceduresResponse> GetMedicalProcedures(GetMedicalProceduresQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdateMedicalProcedure(UpdateMedicalProcedureCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
