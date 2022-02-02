namespace GovernmentSystem.Infrastructure.Services
{
    public class DriverLicenseCategoryService : IDriverLicenseCategoryService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DriverLicenseCategoryService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Result<DriverLicenseCategoryResponse> GetDriverLicenseCategories(GetDriverLicenseCategoriesQuery query)
        {
            var result = _dbContext.AddressTypes
                .ProjectTo<DriverLicenseCategoryResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<DriverLicenseCategoryResponse> { Successful = true, Items = result ?? new List<DriverLicenseCategoryResponse>() };
        }

        public Result<DriverLicenseCategoryResponse> GetDriverLicenseCategoryById(GetDriverLicenseCategoryByIdQuery query)
        {
            var result = _dbContext.AddressTypes
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<DriverLicenseCategoryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<DriverLicenseCategoryResponse> { Successful = true, Item = result ?? new DriverLicenseCategoryResponse() };
        }
    }
}
