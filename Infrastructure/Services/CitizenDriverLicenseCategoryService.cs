using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Commands;
using GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;
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

        public async Task<RequestResponse> CreateCitizenDriverLicenseCategory(CreateCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken)
        {
            var citizenDriverLicenseCategory = _dbContext.CitizenDriverLicenseCategories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenDriverLicenseCategory != null)
            {
                throw new Exception("The citizen driver license category already exists");
            }
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.Identifier == command.CitizenId);
            var driverLicenseCategory = _dbContext.DriverLicenseCategories.SingleOrDefault(x => x.Identifier == command.DriverLicenseCategoryId);

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
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.Identifier == command.CitizenId);
            var driverLicenseCategory = _dbContext.DriverLicenseCategories.SingleOrDefault(x => x.Identifier == command.DriverLicenseCategoryId);

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
