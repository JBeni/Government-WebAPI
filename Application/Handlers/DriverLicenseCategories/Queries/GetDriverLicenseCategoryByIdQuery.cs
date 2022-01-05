namespace GovernmentSystem.Application.Handlers.DriverLicenseCategories.Queries
{
    public class GetDriverLicenseCategoryByIdQuery : IRequest<DriverLicenseCategoryResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetDriverLicenseCategoryByIdQueryHandler : IRequestHandler<GetDriverLicenseCategoryByIdQuery, DriverLicenseCategoryResponse>
    {
        private readonly IDriverLicenseCategoryService _driverLicenseCategoryService;

        public GetDriverLicenseCategoryByIdQueryHandler(IDriverLicenseCategoryService driverLicenseCategoryService)
        {
            _driverLicenseCategoryService = driverLicenseCategoryService;
        }

        public Task<DriverLicenseCategoryResponse> Handle(GetDriverLicenseCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _driverLicenseCategoryService.GetDriverLicenseCategoryById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the driver license category by Id", ex);
            }
        }
    }
}
