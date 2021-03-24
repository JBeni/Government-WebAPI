using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.BirthCertificates.Queries
{
    public class GetBirthCertificateByIdQuery : IRequest<BirthCertificateByIdResponse>
    {
        public string County { get; set; }
    }

    public class GetBirthCertificateByIdQueryHandler : IRequestHandler<GetBirthCertificateByIdQuery, BirthCertificateByIdResponse>
    {
        private readonly IBirthCertificateService _birthCertificateService;

        public GetBirthCertificateByIdQueryHandler(IBirthCertificateService birthCertificateService)
        {
            _birthCertificateService = birthCertificateService;
        }

        public Task<BirthCertificateByIdResponse> Handle(GetBirthCertificateByIdQuery request, CancellationToken cancellationToken)
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

    public class BirthCertificateByIdResponse : IMapFrom<BirthCertificate>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<BirthCertificate, BirthCertificateByIdResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
