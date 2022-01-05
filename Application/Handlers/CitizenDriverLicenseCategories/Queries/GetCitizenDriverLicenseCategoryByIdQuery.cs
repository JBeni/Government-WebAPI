namespace GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Queries
{
    public class GetCitizenDriverLicenseCategoryByIdQuery : IRequest<CitizenDriverLicenseCategoryResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCitizenDriverLicenseCategoryByIdQueryHandler : IRequestHandler<GetCitizenDriverLicenseCategoryByIdQuery, CitizenDriverLicenseCategoryResponse>
    {
        private readonly ICitizenDriverLicenseCategoryService _citizenDriverLicenseCategoryService;

        public GetCitizenDriverLicenseCategoryByIdQueryHandler(ICitizenDriverLicenseCategoryService citizenDriverLicenseCategoryService)
        {
            _citizenDriverLicenseCategoryService = citizenDriverLicenseCategoryService;
        }

        public Task<CitizenDriverLicenseCategoryResponse> Handle(GetCitizenDriverLicenseCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenDriverLicenseCategoryService.GetCitizenDriverLicenseCategoryById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the citizen driver license category by Id", ex);
            }
        }
    }
}
