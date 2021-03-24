using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantSFOs.Queries
{
    public class GetPublicServantSFOsQuery : IRequest<List<PublicServantSFOsResponse>>
    {
        public string County { get; set; }
    }

    public class GetPublicServantSFOsQueryHandler : IRequestHandler<GetPublicServantSFOsQuery, List<PublicServantSFOsResponse>>
    {
        private readonly IPublicServantSFOService _publicServantSFOService;

        public GetPublicServantSFOsQueryHandler(IPublicServantSFOService publicServantSFOService)
        {
            _publicServantSFOService = publicServantSFOService;
        }

        public Task<List<PublicServantSFOsResponse>> Handle(GetPublicServantSFOsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantSFOService.GetPublicServantSFOs(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class PublicServantSFOsResponse : IMapFrom<PublicServantSFO>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<ReportProblem, PublicServantSFOResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
