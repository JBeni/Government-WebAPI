using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.SeriousFraudOffices.Queries
{
    public class GetSeriousFraudOfficesQuery : IRequest<List<SeriousFraudOfficesResponse>>
    {
        public string County { get; set; }
    }

    public class GetSeriousFraudOfficesQueryHandler : IRequestHandler<GetSeriousFraudOfficesQuery, List<SeriousFraudOfficesResponse>>
    {
        private readonly ISeriousFraudOfficeService _seriousFraudOfficeService;

        public GetSeriousFraudOfficesQueryHandler(ISeriousFraudOfficeService seriousFraudOfficeService)
        {
            _seriousFraudOfficeService = seriousFraudOfficeService;
        }

        public Task<List<SeriousFraudOfficesResponse>> Handle(GetSeriousFraudOfficesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _seriousFraudOfficeService.GetSeriousFraudOffices(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the serious fraud offices", ex);
            }
        }
    }

    public class SeriousFraudOfficesResponse : IMapFrom<SeriousFraudOffice>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<SeriousFraudOffice, SeriousFraudOfficesResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
