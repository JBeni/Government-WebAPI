using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenters.Queries
{
    public class GetMedicalCentersQuery : IRequest<List<MedicalCenterResponse>>
    {
    }

    public class GetMedicalCentersQueryHandler : IRequestHandler<GetMedicalCentersQuery, List<MedicalCenterResponse>>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public GetMedicalCentersQueryHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public Task<List<MedicalCenterResponse>> Handle(GetMedicalCentersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterService.GetMedicalCenters(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
