using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Passports.Queries
{
    public class GetPassportsQuery : IRequest<List<PassportsResponse>>
    {
        public string County { get; set; }
    }

    public class GetPassportsQueryHandler : IRequestHandler<GetPassportsQuery, List<PassportsResponse>>
    {
        private readonly IPassportService _passportService;

        public GetPassportsQueryHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public Task<List<PassportsResponse>> Handle(GetPassportsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _passportService.GetPassports(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class PassportsResponse : IMapFrom<Passport>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Passport, PassportsResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
