using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantGPs.Queries
{
    public class GetPublicServantGPsQuery : IRequest<List<PublicServantGPsResponse>>
    {
        public string County { get; set; }
    }

    public class GetPublicServantGPsQueryHandler : IRequestHandler<GetPublicServantGPsQuery, List<PublicServantGPsResponse>>
    {
        private readonly IPublicServantGPService _publicServantGPService;

        public GetPublicServantGPsQueryHandler(IPublicServantGPService publicServantGPService)
        {
            _publicServantGPService = publicServantGPService;
        }

        public Task<List<PublicServantGPsResponse>> Handle(GetPublicServantGPsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantGPService.GetPublicServantGPs(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class PublicServantGPsResponse : IMapFrom<PublicServantGP>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<PublicServantGP, PublicServantGPsResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
