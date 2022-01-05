﻿namespace GovernmentSystem.Infrastructure.Services
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
                Citizen = citizen,
                DriverLicenseCategory = driverLicenseCategory,
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
            };

            _dbContext.CitizenDriverLicenseCategories.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
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
            return RequestResponse.Success();
        }

        public List<CitizenDriverLicenseCategoryResponse> GetCitizenDriverLicenseCategories(GetCitizenDriverLicenseCategoriesQuery query)
        {
            var result = _dbContext.AddressTypes
                .ProjectTo<CitizenDriverLicenseCategoryResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public CitizenDriverLicenseCategoryResponse GetCitizenDriverLicenseCategoryById(GetCitizenDriverLicenseCategoryByIdQuery query)
        {
            var result = _dbContext.AddressTypes
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<CitizenDriverLicenseCategoryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
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

            citizenDriverLicenseCategory.Citizen = citizen;
            citizenDriverLicenseCategory.DriverLicenseCategory = driverLicenseCategory;
            citizenDriverLicenseCategory.DateOfExpiry = command.DateOfExpiry;
            citizenDriverLicenseCategory.DateOfIssue = command.DateOfIssue;

            _dbContext.CitizenDriverLicenseCategories.Update(citizenDriverLicenseCategory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
