using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.SeriousFraudOffices.Queries
{
    public class GetSeriousFraudOfficeByIdQuery : IRequest<SeriousFraudOfficeByIdResponse>
    {
        public string County { get; set; }
    }

    public class GetSeriousFraudOfficeByIdQueryHandler : IRequestHandler<GetSeriousFraudOfficeByIdQuery, SeriousFraudOfficeByIdResponse>
    {
        private readonly ISeriousFraudOfficeService _seriousFraudOfficeService;

        public GetSeriousFraudOfficeByIdQueryHandler(ISeriousFraudOfficeService seriousFraudOfficeService)
        {
            _seriousFraudOfficeService = seriousFraudOfficeService;
        }

        public Task<SeriousFraudOfficeByIdResponse> Handle(GetSeriousFraudOfficeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _seriousFraudOfficeService.GetSeriousFraudOfficeById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the serious fraud office by Id", ex);
            }
        }
    }

    public class SeriousFraudOfficeByIdResponse : IMapFrom<SeriousFraudOffice>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<SeriousFraudOffice, SeriousFraudOfficeByIdResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
