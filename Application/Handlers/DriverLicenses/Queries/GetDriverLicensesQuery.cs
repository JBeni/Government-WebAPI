namespace GovernmentSystem.Application.Handlers.DriverLicenses.Queries
{
    public class GetDriverLicensesQuery : IRequest<List<DriverLicenseResponse>>
    {
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
                throw new Exception("There was an error retrieving the driver licenses", ex);
            }
        }
    }
}
