namespace GovernmentSystem.Application.Handlers.DriverLicenseCategories.Queries
{
    public class GetDriverLicenseCategoriesQuery : IRequest<Result<DriverLicenseCategoryResponse>>
    {
    }

    public class GetDriverLicenseCategoriesQueryHandler : IRequestHandler<GetDriverLicenseCategoriesQuery, Result<DriverLicenseCategoryResponse>>
    {
        private readonly IDriverLicenseCategoryService _driverLicenseCategoryService;

        public GetDriverLicenseCategoriesQueryHandler(IDriverLicenseCategoryService driverLicenseCategoryService)
        {
            _driverLicenseCategoryService = driverLicenseCategoryService;
        }

        public Task<Result<DriverLicenseCategoryResponse>> Handle(GetDriverLicenseCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _driverLicenseCategoryService.GetDriverLicenseCategories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<DriverLicenseCategoryResponse>
                {
                    Error = $"There was an error retrieving the driver license categories. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
