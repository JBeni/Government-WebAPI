using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.DriverLicenses.Queries
{
    public class GetDriverLicensesQuery : IRequest<List<DriverLicensesResponse>>
    {
        public string County { get; set; }
    }

    public class GetDriverLicensesQueryHandler : IRequestHandler<GetDriverLicensesQuery, List<DriverLicensesResponse>>
    {
        private readonly IDriverLicenseService _driverLicenseService;

        public GetDriverLicensesQueryHandler(IDriverLicenseService driverLicenseService)
        {
            _driverLicenseService = driverLicenseService;
        }

        public Task<List<DriverLicensesResponse>> Handle(GetDriverLicensesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _driverLicenseService.GetDriverLicenses(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class DriverLicensesResponse : IMapFrom<DriverLicense>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<DriverLicense, DriverLicensesResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
