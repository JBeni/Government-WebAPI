using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPolices.Queries
{
    public class GetPublicServantPolicesQuery : IRequest<List<PublicServantPolicesResponse>>
    {
        public string County { get; set; }
    }

    public class GetPublicServantPolicesQueryHandler : IRequestHandler<GetPublicServantPolicesQuery, List<PublicServantPolicesResponse>>
    {
        private readonly IPublicServantPoliceService _publicServantPoliceService;

        public GetPublicServantPolicesQueryHandler(IPublicServantPoliceService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public Task<List<PublicServantPolicesResponse>> Handle(GetPublicServantPolicesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantPoliceService.GetPublicServantPolices(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of police", ex);
            }
        }
    }

    public class PublicServantPolicesResponse : IMapFrom<PublicServantPolice>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<PublicServantPolice, PublicServantPolicesResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
