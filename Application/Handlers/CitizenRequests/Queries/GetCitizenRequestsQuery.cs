using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CitizenRequests.Queries
{
    public class GetCitizenRequestsQuery : IRequest<List<CitizenRequestsResponse>>
    {
        public int Id { get; set; }
    }

    public class GetCitizenRequestsQueryHandler : IRequestHandler<GetCitizenRequestsQuery, List<CitizenRequestsResponse>>
    {
        private readonly ICitizenRequestService _citizenRequestService;

        public GetCitizenRequestsQueryHandler(ICitizenRequestService citizenRequestService)
        {
            _citizenRequestService = citizenRequestService;
        }

        public Task<List<CitizenRequestsResponse>> Handle(GetCitizenRequestsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenRequestService.GetCitizenRequests(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the medical history of citizen", ex);
            }
        }
    }

    public class CitizenRequestsResponse : IMapFrom<CitizenRequest>
    {
        public void Mapping(Profile profile)
        {
            //profile.CreateMap<CitizenRequest, CitizenRequestsResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
