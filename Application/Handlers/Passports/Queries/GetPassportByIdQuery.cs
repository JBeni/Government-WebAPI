using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Passports.Queries
{
    public class GetPassportByIdQuery : IRequest<PassportResponse>
    {
        public string County { get; set; }
    }

    public class GetPassportByIdQueryHandler : IRequestHandler<GetPassportByIdQuery, PassportResponse>
    {
        private readonly IPassportService _passportService;

        public GetPassportByIdQueryHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public Task<PassportResponse> Handle(GetPassportByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _passportService.GetPassportById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class PassportResponse : IMapFrom<Passport>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Passport, PassportResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
