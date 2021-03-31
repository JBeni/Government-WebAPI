using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Commands;
using GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public Task<RequestResponse> CreateCitizenDriverLicenseCategory(CreateCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<RequestResponse> DeleteCitizenDriverLicenseCategory(DeleteCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
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

        public Task<RequestResponse> UpdateCitizenDriverLicenseCategory(UpdateCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
