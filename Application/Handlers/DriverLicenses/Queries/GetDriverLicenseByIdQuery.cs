using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.DriverLicenses.Queries
{
    public class GetDriverLicenseByIdQuery : IRequest<DriverLicenseResponse>
    {
        public string County { get; set; }
    }

    public class GetDriverLicenseByIdQueryHandler : IRequestHandler<GetDriverLicenseByIdQuery, DriverLicenseResponse>
    {
        private readonly IDriverLicenseService _driverLicenseByIdService;

        public GetDriverLicenseByIdQueryHandler(IDriverLicenseService driverLicenseByIdService)
        {
            _driverLicenseByIdService = driverLicenseByIdService;
        }

        public Task<DriverLicenseResponse> Handle(GetDriverLicenseByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _driverLicenseByIdService.GetDriverLicenseById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class DriverLicenseResponse : IMapFrom<DriverLicense>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<DriverLicense, DriverLicenseResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
