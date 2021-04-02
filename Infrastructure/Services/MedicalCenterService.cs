using GovernmentSystem.Application.Handlers.MedicalCenters.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using System.Collections.Generic;
using GovernmentSystem.Application.Handlers.MedicalCenters.Queries;
using GovernmentSystem.Application.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalCenterService : IMedicalCenterService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MedicalCenterService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateMedicalCenter(CreateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenter != null)
            {
                throw new Exception("The medical center already exists");
            }
            var address = _dbContext.Addresses.SingleOrDefault(x => x.Identifier == command.AddressId);
            var entity = new MedicalCenter
            {
                Address = address,
                CenterName = command.CenterName,
                ConstructionDate = command.ConstructionDate,
            };

            _dbContext.MedicalCenters.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteMedicalCenter(DeleteMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenter == null)
            {
                throw new Exception("The medical center does not exists");
            }

            _dbContext.MedicalCenters.Remove(medicalCenter);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public MedicalCenterResponse GetMedicalCenterById(GetMedicalCenterByIdQuery query)
        {
            var result = _dbContext.MedicalCenters
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalCenterResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<MedicalCenterResponse> GetMedicalCenters(GetMedicalCentersQuery query)
        {
            var result = _dbContext.MedicalCenters
                .ProjectTo<MedicalCenterResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateMedicalCenter(UpdateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenter == null)
            {
                throw new Exception("The medical center does not exists");
            }
            var address = _dbContext.Addresses.SingleOrDefault(x => x.Identifier == command.AddressId);
            medicalCenter.Address = address;
            medicalCenter.CenterName = command.CenterName;
            medicalCenter.ConstructionDate = command.ConstructionDate;

            _dbContext.MedicalCenters.Update(medicalCenter);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
