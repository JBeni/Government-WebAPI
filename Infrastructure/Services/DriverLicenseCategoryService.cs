using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Handlers.DriverLicenseCategories.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Linq;

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

        public List<DriverLicenseCategoryResponse> GetDriverLicenseCategories(GetDriverLicenseCategoriesQuery query)
        {
            var result = _dbContext.AddressTypes
                .ProjectTo<DriverLicenseCategoryResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public DriverLicenseCategoryResponse GetDriverLicenseCategoryById(GetDriverLicenseCategoryByIdQuery query)
        {
            var result = _dbContext.AddressTypes
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<DriverLicenseCategoryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }
    }
}
