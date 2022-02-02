namespace GovernmentSystem.Application.Handlers.DriverLicenses.Queries
{
    public class GetDriverLicensesQuery : IRequest<Result<DriverLicenseResponse>>
    {
    }

    public class GetDriverLicensesQueryHandler : IRequestHandler<GetDriverLicensesQuery, Result<DriverLicenseResponse>>
    {
        private readonly IDriverLicenseService _driverLicenseService;

        public GetDriverLicensesQueryHandler(IDriverLicenseService driverLicenseService)
        {
            _driverLicenseService = driverLicenseService;
        }

        public Task<Result<DriverLicenseResponse>> Handle(GetDriverLicensesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _driverLicenseService.GetDriverLicenses(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<DriverLicenseResponse>
                {
                    Error = $"There was an error retrieving the driver licenses. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
