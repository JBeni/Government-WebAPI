using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.DriverLicenses.Queries
{
    public class GetDriverLicenseByIdQuery : IRequest<DriverLicenseResponse>
    {
        public Guid Identifier { get; set; }
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
                throw new Exception("There was an error retrieving the driver license by Id", ex);
            }
        }
    }
}
