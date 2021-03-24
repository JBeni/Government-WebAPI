using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.DriverLicenses.Queries
{
    public class GetDriverLicensesQuery : IRequest<List<DriverLicenseResponse>>
    {
        public string County { get; set; }
    }

    public class GetDriverLicensesQueryHandler : IRequestHandler<GetDriverLicensesQuery, List<DriverLicenseResponse>>
    {
        private readonly IDriverLicenseService _driverLicenseService;

        public GetDriverLicensesQueryHandler(IDriverLicenseService driverLicenseService)
        {
            _driverLicenseService = driverLicenseService;
        }

        public Task<List<DriverLicenseResponse>> Handle(GetDriverLicensesQuery request, CancellationToken cancellationToken)
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
}
