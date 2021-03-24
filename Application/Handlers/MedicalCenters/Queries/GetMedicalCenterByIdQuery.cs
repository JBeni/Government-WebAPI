using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenterById.Queries
{
    public class GetMedicalCenterByIdQuery : IRequest<MedicalCenterResponse>
    {
        public string County { get; set; }
    }

    public class GetMedicalCenterByIdQueryHandler : IRequestHandler<GetMedicalCenterByIdQuery, MedicalCenterResponse>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public GetMedicalCenterByIdQueryHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public Task<MedicalCenterResponse> Handle(GetMedicalCenterByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterService.GetMedicalCenterById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
