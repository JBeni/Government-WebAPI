namespace GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Queries
{
    public class GetCitizenDriverLicenseCategoryByIdQuery : IRequest<Result<CitizenDriverLicenseCategoryResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCitizenDriverLicenseCategoryByIdQueryHandler : IRequestHandler<GetCitizenDriverLicenseCategoryByIdQuery, Result<CitizenDriverLicenseCategoryResponse>>
    {
        private readonly ICitizenDriverLicenseCategoryService _citizenDriverLicenseCategoryService;

        public GetCitizenDriverLicenseCategoryByIdQueryHandler(ICitizenDriverLicenseCategoryService citizenDriverLicenseCategoryService)
        {
            _citizenDriverLicenseCategoryService = citizenDriverLicenseCategoryService;
        }

        public Task<Result<CitizenDriverLicenseCategoryResponse>> Handle(GetCitizenDriverLicenseCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenDriverLicenseCategoryService.GetCitizenDriverLicenseCategoryById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CitizenDriverLicenseCategoryResponse>
                {
                    Error = $"There was an error retrieving the citizen driver license category by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
