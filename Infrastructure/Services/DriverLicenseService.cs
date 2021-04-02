using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.DriverLicenses.Commands;
using GovernmentSystem.Application.Handlers.DriverLicenses.Queries;
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
    public class DriverLicenseService : IDriverLicenseService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DriverLicenseService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateDriverLicense(CreateDriverLicenseCommand command, CancellationToken cancellationToken)
        {
            var driverLicense = _dbContext.DriverLicenses.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (driverLicense != null)
            {
                throw new Exception("The driver license already exists");
            }
            var entity = new DriverLicense
            {
                LicenseNumber = command.LicenseNumber
            };

            _dbContext.DriverLicenses.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteDriverLicense(DeleteDriverLicenseCommand command, CancellationToken cancellationToken)
        {
            var driverLicense = _dbContext.DriverLicenses.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (driverLicense != null)
            {
                throw new Exception("The driver license does not exists");
            }

            _dbContext.DriverLicenses.Remove(driverLicense);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public DriverLicenseResponse GetDriverLicenseById(GetDriverLicenseByIdQuery query)
        {
            var result = _dbContext.DriverLicenses
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<DriverLicenseResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<DriverLicenseResponse> GetDriverLicenses(GetDriverLicensesQuery query)
        {
            var result = _dbContext.DriverLicenses
                .ProjectTo<DriverLicenseResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateDriverLicense(UpdateDriverLicenseCommand command, CancellationToken cancellationToken)
        {
            var driverLicense = _dbContext.DriverLicenses.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (driverLicense != null)
            {
                throw new Exception("The driver license does not exists");
            }
            driverLicense.LicenseNumber = command.LicenseNumber;

            _dbContext.DriverLicenses.Update(driverLicense);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
