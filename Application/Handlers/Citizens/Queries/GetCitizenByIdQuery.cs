using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;
using GovernmentSystem.Application.Interfaces;

namespace GovernmentSystem.Application.Handlers.Citizens.Queries
{
    public class GetCitizenByIdQuery : IRequest<CitizenResponse>
    {
        public int Id { get; set; }
    }

    public class GetCitizenByIdQueryHandler : IRequestHandler<GetCitizenByIdQuery, CitizenResponse>
    {
        private readonly ICitizenService _citizenService;

        public GetCitizenByIdQueryHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public Task<CitizenResponse> Handle(GetCitizenByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenService.GetCitizenById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class CitizenResponse : IMapFrom<Citizen>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Citizen, CitizenResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
