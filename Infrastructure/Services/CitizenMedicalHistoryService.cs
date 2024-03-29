﻿namespace GovernmentSystem.Infrastructure.Services
{
    public class CitizenMedicalHistoryService : ICitizenMedicalHistoryService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public CitizenMedicalHistoryService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateCitizenMedicalHistory(CreateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            var citizenMedicalHistory = _dbContext.CitizenMedicalHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenMedicalHistory != null)
            {
                throw new Exception("The citizen medical history request already exists");
            }
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var publicServantMedicalCenter = _insideEntityService.GetPublicServantMedicalCenterById(command.PublicServantMedicalCenterId);
            var medicalAppointment = _insideEntityService.GetMedicalAppointmentById(command.MedicalAppointmentId);
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);

            var entity = new CitizenMedicalHistory
            {
                AdditionalInformation = command.AdditionalInformation,
                DateOfDiagnostic = command.DateOfDiagnostic,
                HealthProblem = command.HealthProblem,
                Symptoms = command.Symptoms,
                Treatment = command.Treatment,
                MedicalCenter = medicalCenter.Item,
                PublicServantMedicalCenter = publicServantMedicalCenter.Item,
                MedicalAppointment = medicalAppointment.Item,
                Citizen = citizen.Item,
            };

            _dbContext.CitizenMedicalHistories.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteCitizenMedicalHistory(DeleteCitizenMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            var citizenMedicalHistory = _dbContext.CitizenMedicalHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenMedicalHistory == null)
            {
                throw new Exception("The citizen medical history request does not exists");
            }

            _dbContext.CitizenMedicalHistories.Remove(citizenMedicalHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(citizenMedicalHistory.Identifier);
        }

        public Result<CitizenMedicalHistoryResponse> GetCitizenMedicalHistories(GetCitizenMedicalHistoriesQuery query)
        {
            var result = _dbContext.CitizenMedicalHistories
                .ProjectTo<CitizenMedicalHistoryResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<CitizenMedicalHistoryResponse> { Successful = true, Items = result ?? new List<CitizenMedicalHistoryResponse>() };
        }

        public Result<CitizenMedicalHistoryResponse> GetCitizenMedicalHistoryById(GetCitizenMedicalHistoryByIdQuery query)
        {
            var result = _dbContext.CitizenMedicalHistories
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<CitizenMedicalHistoryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<CitizenMedicalHistoryResponse> { Successful = true, Item = result ?? new CitizenMedicalHistoryResponse() };
        }

        public async Task<RequestResponse> UpdateCitizenMedicalHistory(UpdateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            var citizenMedicalHistory = _dbContext.CitizenMedicalHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenMedicalHistory == null)
            {
                throw new Exception("The citizen medical history request does not exists");
            }
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var publicServantMedicalCenter = _insideEntityService.GetPublicServantMedicalCenterById(command.PublicServantMedicalCenterId);
            var medicalAppointment = _insideEntityService.GetMedicalAppointmentById(command.MedicalAppointmentId);
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);

            citizenMedicalHistory.AdditionalInformation = command.AdditionalInformation;
            citizenMedicalHistory.DateOfDiagnostic = command.DateOfDiagnostic;
            citizenMedicalHistory.HealthProblem = command.HealthProblem;
            citizenMedicalHistory.Symptoms = command.Symptoms;
            citizenMedicalHistory.Treatment = command.Treatment;
            citizenMedicalHistory.MedicalCenter = medicalCenter.Item;
            citizenMedicalHistory.PublicServantMedicalCenter = publicServantMedicalCenter.Item;
            citizenMedicalHistory.MedicalAppointment = medicalAppointment.Item;
            citizenMedicalHistory.Citizen = citizen.Item;

            _dbContext.CitizenMedicalHistories.Update(citizenMedicalHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(citizenMedicalHistory.Identifier);
        }
    }
}
