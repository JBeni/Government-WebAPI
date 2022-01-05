﻿namespace GovernmentSystem.Infrastructure.Services
{
    public class CitizenRecordService : ICitizenRecordService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public CitizenRecordService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateCitizenRecord(CreateCitizenRecordCommand command, CancellationToken cancellationToken)
        {
            var citizenRecord = _dbContext.CitizenRecords.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenRecord != null)
            {
                throw new Exception("The citizen record already exists");
            }
            var policeStation = _insideEntityService.GetPoliceStationById(command.PoliceStationId);
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);

            var entity = new CitizenRecord
            {
                Reason = command.Reason,
                DateOfIssue = command.DateOfIssue,
                Description = command.Description,
                Witnesses = command.Witnesses,
                CriminalityType = command.CriminalityType,
                PoliceStation = policeStation,
                Citizen = citizen
            };

            _dbContext.CitizenRecords.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteCitizenRecord(DeleteCitizenRecordCommand command, CancellationToken cancellationToken)
        {
            var citizenRecord = _dbContext.CitizenRecords.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenRecord == null)
            {
                throw new Exception("The citizen record does not exists");
            }

            _dbContext.CitizenRecords.Remove(citizenRecord);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public CitizenRecordResponse GetCitizenRecordById(GetCitizenRecordByIdQuery query)
        {
            var result = _dbContext.CitizenRecords
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<CitizenRecordResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<CitizenRecordResponse> GetCitizenRecords(GetCitizenRecordsQuery query)
        {
            var result = _dbContext.CitizenRecords
                .ProjectTo<CitizenRecordResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateCitizenRecord(UpdateCitizenRecordCommand command, CancellationToken cancellationToken)
        {
            var citizenRecord = _dbContext.CitizenRecords.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenRecord == null)
            {
                throw new Exception("The citizen record does not exists");
            }
            var policeStation = _insideEntityService.GetPoliceStationById(command.PoliceStationId);
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);

            citizenRecord.Reason = command.Reason;
            citizenRecord.DateOfIssue = command.DateOfIssue;
            citizenRecord.Description = command.Description;
            citizenRecord.Witnesses = command.Witnesses;
            citizenRecord.CriminalityType = command.CriminalityType;
            citizenRecord.PoliceStation = policeStation;
            citizenRecord.Citizen = citizen;

            _dbContext.CitizenRecords.Update(citizenRecord);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}