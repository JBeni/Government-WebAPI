﻿namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalCenterService : IMedicalCenterService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public MedicalCenterService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateMedicalCenter(CreateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenter != null)
            {
                throw new Exception("The medical center already exists");
            }
            var address = _insideEntityService.GetAddressById(command.AddressId);
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
            var address = _insideEntityService.GetAddressById(command.AddressId);
            medicalCenter.Address = address;
            medicalCenter.CenterName = command.CenterName;
            medicalCenter.ConstructionDate = command.ConstructionDate;

            _dbContext.MedicalCenters.Update(medicalCenter);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
