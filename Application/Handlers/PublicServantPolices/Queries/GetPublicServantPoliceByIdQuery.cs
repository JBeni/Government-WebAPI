using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPolices.Queries
{
    public class GetPublicServantPoliceByIdQuery : IRequest<PublicServantPoliceByIdResponse>
    {
        public string County { get; set; }
    }

    public class GetPublicServantPoliceByIdQueryHandler : IRequestHandler<GetPublicServantPoliceByIdQuery, PublicServantPoliceByIdResponse>
    {
        private readonly IPublicServantPoliceService _publicServantPoliceService;

        public GetPublicServantPoliceByIdQueryHandler(IPublicServantPoliceService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public Task<PublicServantPoliceByIdResponse> Handle(GetPublicServantPoliceByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantPoliceService.GetPublicServantPoliceById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servant of police by Id", ex);
            }
        }
    }

    public class PublicServantPoliceByIdResponse : IMapFrom<PublicServantPolice>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<PublicServantPolice, PublicServantPoliceByIdResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
