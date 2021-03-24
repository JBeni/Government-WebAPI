using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Queries
{
    public class GetMedicalProcedureByIdQuery : IRequest<MedicalProcedureResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetMedicalProcedureByIdQueryHandler : IRequestHandler<GetMedicalProcedureByIdQuery, MedicalProcedureResponse>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public GetMedicalProcedureByIdQueryHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public Task<MedicalProcedureResponse> Handle(GetMedicalProcedureByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalProcedureservice.GetMedicalProcedureById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
