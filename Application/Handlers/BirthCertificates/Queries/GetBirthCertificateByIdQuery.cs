using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.BirthCertificates.Queries
{
    public class GetBirthCertificateByIdQuery : IRequest<BirthCertificateResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetBirthCertificateByIdQueryHandler : IRequestHandler<GetBirthCertificateByIdQuery, BirthCertificateResponse>
    {
        private readonly IBirthCertificateService _birthCertificateService;

        public GetBirthCertificateByIdQueryHandler(IBirthCertificateService birthCertificateService)
        {
            _birthCertificateService = birthCertificateService;
        }

        public Task<BirthCertificateResponse> Handle(GetBirthCertificateByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _birthCertificateService.GetBirthCertificateById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
    }
}
