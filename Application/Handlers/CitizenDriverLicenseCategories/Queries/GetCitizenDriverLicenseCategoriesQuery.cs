namespace GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Queries
{
    public class GetCitizenDriverLicenseCategoriesQuery : IRequest<Result<CitizenDriverLicenseCategoryResponse>>
    {
    }

    public class GetCitizenDriverLicenseCategoriesQueryHandler : IRequestHandler<GetCitizenDriverLicenseCategoriesQuery, Result<CitizenDriverLicenseCategoryResponse>>
    {
        private readonly ICitizenDriverLicenseCategoryService _citizenDriverLicenseCategoryService;

        public GetCitizenDriverLicenseCategoriesQueryHandler(ICitizenDriverLicenseCategoryService citizenDriverLicenseCategoryService)
        {
            _citizenDriverLicenseCategoryService = citizenDriverLicenseCategoryService;
        }

        public Task<Result<CitizenDriverLicenseCategoryResponse>> Handle(GetCitizenDriverLicenseCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenDriverLicenseCategoryService.GetCitizenDriverLicenseCategories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CitizenDriverLicenseCategoryResponse>
                {
                    Error = $"There was an error retrieving the citizen driver license categories. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
