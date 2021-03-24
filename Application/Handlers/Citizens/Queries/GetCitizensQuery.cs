using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Interfaces;
using System;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Application.Common.Mappings;

namespace GovernmentSystem.Application.Handlers.Citizens.Queries
{
    public class GetCitizensQuery : IRequest<List<CitizensResponse>>
    {
    }

    public class GetCitizensQueryHandler : IRequestHandler<GetCitizensQuery, List<CitizensResponse>>
    {
        private readonly ICitizenService _citizenService;

        public GetCitizensQueryHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public Task<List<CitizensResponse>> Handle(GetCitizensQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenService.GetCitizens(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class CitizensResponse : IMapFrom<Citizen>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Citizen, CitizensResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
