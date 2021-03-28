using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Queries
{
    public class GetMedicalCenterProceduresQuery : IRequest<List<MedicalCenterProcedureResponse>>
    {
    }

    public class GetMedicalCenterProceduresQueryHandler : IRequestHandler<GetMedicalCenterProceduresQuery, List<MedicalCenterProcedureResponse>>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public GetMedicalCenterProceduresQueryHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public Task<List<MedicalCenterProcedureResponse>> Handle(GetMedicalCenterProceduresQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterProcedureService.GetMedicalCenterProcedures(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the medical center procedures", ex);
            }
        }
    }
}
