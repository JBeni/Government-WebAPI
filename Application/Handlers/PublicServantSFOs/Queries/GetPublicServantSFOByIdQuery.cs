using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantSFOs.Queries
{
    public class GetPublicServantSFOByIdQuery : IRequest<PublicServantSFOByIdResponse>
    {
        public string County { get; set; }
    }

    public class GetPublicServantSFOQueryHandler : IRequestHandler<GetPublicServantSFOByIdQuery, PublicServantSFOByIdResponse>
    {
        private readonly IPublicServantSFOService _publicServantSFOService;

        public GetPublicServantSFOQueryHandler(IPublicServantSFOService publicServantSFOService)
        {
            _publicServantSFOService = publicServantSFOService;
        }

        public Task<PublicServantSFOByIdResponse> Handle(GetPublicServantSFOByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantSFOService.GetPublicServantSFOById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servant of serious fraud office by Id", ex);
            }
        }
    }

    public class PublicServantSFOByIdResponse : IMapFrom<PublicServantSFO>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<ReportProblem, PublicServantSFOResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
