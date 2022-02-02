namespace GovernmentSystem.Application.Handlers.DriverLicenses.Queries
{
    public class GetDriverLicenseByIdQuery : IRequest<Result<DriverLicenseResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetDriverLicenseByIdQueryHandler : IRequestHandler<GetDriverLicenseByIdQuery, Result<DriverLicenseResponse>>
    {
        private readonly IDriverLicenseService _driverLicenseService;

        public GetDriverLicenseByIdQueryHandler(IDriverLicenseService driverLicenseService)
        {
            _driverLicenseService = driverLicenseService;
        }

        public Task<Result<DriverLicenseResponse>> Handle(GetDriverLicenseByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _driverLicenseService.GetDriverLicenseById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<DriverLicenseResponse>
                {
                    Error = $"There was an error retrieving the driver license by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
