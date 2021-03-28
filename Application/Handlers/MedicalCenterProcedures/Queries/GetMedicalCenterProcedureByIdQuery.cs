using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Queries
{
    public class GetMedicalCenterProcedureByIdQuery : IRequest<MedicalCenterProcedureResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetMedicalCenterProcedureByIdQueryHandler : IRequestHandler<GetMedicalCenterProcedureByIdQuery, MedicalCenterProcedureResponse>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public GetMedicalCenterProcedureByIdQueryHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public Task<MedicalCenterProcedureResponse> Handle(GetMedicalCenterProcedureByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterProcedureService.GetMedicalCenterProcedureById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the medical center procedure by Id", ex);
            }
        }
    }
}
