using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Linq;

namespace GovernmentSystem.Infrastructure.Services
{
    public class CitizenDriverLicenseCategoryService : ICitizenDriverLicenseCategoryService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CitizenDriverLicenseCategoryService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
    }
}
