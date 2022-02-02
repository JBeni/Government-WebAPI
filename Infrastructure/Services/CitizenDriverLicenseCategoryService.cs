namespace GovernmentSystem.Infrastructure.Services
{
    public class CitizenDriverLicenseCategoryService : ICitizenDriverLicenseCategoryService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public CitizenDriverLicenseCategoryService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateCitizenDriverLicenseCategory(CreateCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken)
        {
            var citizenDriverLicenseCategory = _dbContext.CitizenDriverLicenseCategories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenDriverLicenseCategory != null)
            {
                throw new Exception("The citizen driver license category already exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var driverLicenseCategory = _insideEntityService.GetDriverLicenseCategoryById(command.DriverLicenseCategoryId);

            var entity = new CitizenDriverLicenseCategory
            {
                Citizen = citizen.Item,
                DriverLicenseCategory = driverLicenseCategory.Item,
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
            };

            _dbContext.CitizenDriverLicenseCategories.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteCitizenDriverLicenseCategory(DeleteCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken)
        {
            var citizenDriverLicenseCategory = _dbContext.CitizenDriverLicenseCategories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenDriverLicenseCategory != null)
            {
                throw new Exception("The citizen driver license category does not exists");
            }

            _dbContext.CitizenDriverLicenseCategories.Remove(citizenDriverLicenseCategory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(citizenDriverLicenseCategory.Identifier);
        }

        public Result<CitizenDriverLicenseCategoryResponse> GetCitizenDriverLicenseCategories(GetCitizenDriverLicenseCategoriesQuery query)
        {
            var result = _dbContext.AddressTypes
                .ProjectTo<CitizenDriverLicenseCategoryResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<CitizenDriverLicenseCategoryResponse> { Successful = true, Items = result ?? new List<CitizenDriverLicenseCategoryResponse>() };
        }

        public Result<CitizenDriverLicenseCategoryResponse> GetCitizenDriverLicenseCategoryById(GetCitizenDriverLicenseCategoryByIdQuery query)
        {
            var result = _dbContext.AddressTypes
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<CitizenDriverLicenseCategoryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<CitizenDriverLicenseCategoryResponse> { Successful = true, Item = result ?? new CitizenDriverLicenseCategoryResponse() };
        }

        public async Task<RequestResponse> UpdateCitizenDriverLicenseCategory(UpdateCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken)
        {
            var citizenDriverLicenseCategory = _dbContext.CitizenDriverLicenseCategories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenDriverLicenseCategory != null)
            {
                throw new Exception("The citizen driver license category does not exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var driverLicenseCategory = _insideEntityService.GetDriverLicenseCategoryById(command.DriverLicenseCategoryId);

            citizenDriverLicenseCategory.Citizen = citizen.Item;
            citizenDriverLicenseCategory.DriverLicenseCategory = driverLicenseCategory.Item;
            citizenDriverLicenseCategory.DateOfExpiry = command.DateOfExpiry;
            citizenDriverLicenseCategory.DateOfIssue = command.DateOfIssue;

            _dbContext.CitizenDriverLicenseCategories.Update(citizenDriverLicenseCategory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(citizenDriverLicenseCategory.Identifier);
        }
    }
}
