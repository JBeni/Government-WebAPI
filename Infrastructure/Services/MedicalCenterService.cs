using GovernmentSystem.Application.Handlers.MedicalCenters.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using GovernmentSystem.Application.Handlers.MedicalCenterById.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Handlers.MedicalCenters.Queries;

namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalCenterService : IMedicalCenterService
    {
        private readonly IApplicationDbContext _dbContext;

        public MedicalCenterService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> CreateMedicalCenter(CreateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.UniqueIdentifier == command.UniqueIdentifier);
            if (medicalCenter != null)
            {
                throw new Exception("The medical center already exists");
            }

            var entity = new MedicalCenter
            {
            };

            _dbContext.MedicalCenters.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteMedicalCenter(DeleteMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.UniqueIdentifier == command.UniqueIdentifier);
            if (medicalCenter == null)
            {
                throw new Exception("The medical center does not exists");
            }

            _dbContext.MedicalCenters.Update(medicalCenter);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public MedicalCenterResponse GetMedicalCenterById(GetMedicalCenterByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<MedicalCentersResponse> GetMedicalCenters(GetMedicalCentersQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResponse> UpdateMedicalCenter(UpdateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.UniqueIdentifier == command.UniqueIdentifier);
            if (medicalCenter == null)
            {
                throw new Exception("The medical center does not exists");
            }
            //medicalCenter.Something = "";

            _dbContext.MedicalCenters.Update(medicalCenter);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
