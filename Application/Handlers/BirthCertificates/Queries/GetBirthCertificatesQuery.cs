using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.BirthCertificates.Queries
{
    public class GetBirthCertificatesQuery : IRequest<List<BirthCertificateResponse>>
    {
        public string County { get; set; }
    }

    public class GetBirthCertificatesQueryHandler : IRequestHandler<GetBirthCertificatesQuery, List<BirthCertificateResponse>>
    {
        private readonly IBirthCertificateService _birthCertificateService;

        public GetBirthCertificatesQueryHandler(IBirthCertificateService birthCertificateService)
        {
            _birthCertificateService = birthCertificateService;
        }

        public Task<List<BirthCertificateResponse>> Handle(GetBirthCertificatesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _birthCertificateService.GetBirthCertificates(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
    }
}
