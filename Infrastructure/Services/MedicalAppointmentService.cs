namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalAppointmentService : IMedicalAppointmentService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public MedicalAppointmentService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateMedicalAppointment(CreateMedicalAppointmentCommand command, CancellationToken cancellationToken)
        {
            var medicalAppointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalAppointment != null)
            {
                throw new Exception("The medical appointment already exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var medicalProcedure = _insideEntityService.GetMedicalProcedureById(command.MedicalProcedureId);
            var publicServantMedicalCenter = _insideEntityService.GetPublicServantMedicalCenterById(command.PublicServantMedicalCenterId);

            var entity = new MedicalAppointment
            {
                AppointmentDay = command.AppointmentDay,
                Symptoms = command.Symptoms,
                Citizen = citizen.Item,
                MedicalCenter = medicalCenter.Item,
                MedicalProcedure = medicalProcedure.Item,
                PublicServantMedicalCenter = publicServantMedicalCenter.Item,
            };

            _dbContext.MedicalAppointments.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteMedicalAppointment(DeleteMedicalAppointmentCommand command, CancellationToken cancellationToken)
        {
            var medicalAppointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalAppointment == null)
            {
                throw new Exception("The medical appointment does not exists");
            }

            _dbContext.MedicalAppointments.Remove(medicalAppointment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(medicalAppointment.Identifier);
        }

        public Result<MedicalAppointmentResponse> GetMedicalAppointmentById(GetMedicalAppointmentByIdQuery query)
        {
            var result = _dbContext.MedicalAppointments
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalAppointmentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<MedicalAppointmentResponse> { Successful = true, Item = result ?? new MedicalAppointmentResponse() };
        }

        public Result<MedicalAppointmentResponse> GetMedicalAppointments(GetMedicalAppointmentsQuery query)
        {
            var result = _dbContext.MedicalAppointments
                .ProjectTo<MedicalAppointmentResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<MedicalAppointmentResponse> { Successful = true, Items = result ?? new List<MedicalAppointmentResponse>() };
        }

        public async Task<RequestResponse> UpdateMedicalAppointment(UpdateMedicalAppointmentCommand command, CancellationToken cancellationToken)
        {
            var medicalAppointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalAppointment == null)
            {
                throw new Exception("The medical appointment does not exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var medicalProcedure = _insideEntityService.GetMedicalProcedureById(command.MedicalProcedureId);
            var publicServantMedicalCenter = _insideEntityService.GetPublicServantMedicalCenterById(command.PublicServantMedicalCenterId);

            medicalAppointment.AppointmentDay = command.AppointmentDay;
            medicalAppointment.Symptoms = command.Symptoms;
            medicalAppointment.MedicalCenter = medicalCenter.Item;
            medicalAppointment.MedicalProcedure = medicalProcedure.Item;
            medicalAppointment.PublicServantMedicalCenter = publicServantMedicalCenter.Item;

            _dbContext.MedicalAppointments.Update(medicalAppointment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(medicalAppointment.Identifier);
        }
    }
}
