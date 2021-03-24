using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantGPs.Queries
{
    public class GetPublicServantGPByIdQuery : IRequest<PublicServantGPByIdResponse>
    {
        public string County { get; set; }
    }

    public class GetPublicServantGPByIdQueryHandler : IRequestHandler<GetPublicServantGPByIdQuery, PublicServantGPByIdResponse>
    {
        private readonly IPublicServantGPService _publicServantGPService;

        public GetPublicServantGPByIdQueryHandler(IPublicServantGPService publicServantGPService)
        {
            _publicServantGPService = publicServantGPService;
        }

        public Task<PublicServantGPByIdResponse> Handle(GetPublicServantGPByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantGPService.GetPublicServantGPById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class PublicServantGPByIdResponse : IMapFrom<PublicServantGP>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<PublicServantGP, PublicServantGPByIdResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
