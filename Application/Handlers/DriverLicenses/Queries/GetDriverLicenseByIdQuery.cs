namespace GovernmentSystem.Application.Handlers.DriverLicenses.Queries
{
    public class GetDriverLicenseByIdQuery : IRequest<DriverLicenseResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetDriverLicenseByIdQueryHandler : IRequestHandler<GetDriverLicenseByIdQuery, DriverLicenseResponse>
    {
        private readonly IDriverLicenseService _driverLicenseService;

        public GetDriverLicenseByIdQueryHandler(IDriverLicenseService driverLicenseService)
        {
            _driverLicenseService = driverLicenseService;
        }

        public Task<DriverLicenseResponse> Handle(GetDriverLicenseByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _driverLicenseService.GetDriverLicenseById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the driver license by Id", ex);
            }
        }
    }
}
