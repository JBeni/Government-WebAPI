namespace GovernmentSystem.Infrastructure.Services
{
    public class IdentityCardAppointmentService : IIdentityCardAppointmentService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public IdentityCardAppointmentService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateIdentityCardAppointment(CreateIdentityCardAppointmentCommand command, CancellationToken cancellationToken)
        {
            var identityCardAppointment = _dbContext.IdentityCardAppointments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (identityCardAppointment != null)
            {
                throw new Exception("The identity card appointment already exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var entity = new IdentityCardAppointment
            {
                AdditionalInformation = command.AdditionalInformation,
                AppointmentDay = command.AppointmentDay,
                Citizen = citizen,
                Reason = command.Reason
            };

            _dbContext.IdentityCardAppointments.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteIdentityCardAppointment(DeleteIdentityCardAppointmentCommand command, CancellationToken cancellationToken)
        {
            var identityCardAppointment = _dbContext.IdentityCardAppointments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (identityCardAppointment != null)
            {
                throw new Exception("The identity card appointment does not exists");
            }

            _dbContext.IdentityCardAppointments.Remove(identityCardAppointment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public IdentityCardAppointmentResponse GetIdentityCardAppointmentById(GetIdentityCardAppointmentByIdQuery query)
        {
            var result = _dbContext.IdentityCardAppointments
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<IdentityCardAppointmentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<IdentityCardAppointmentResponse> GetIdentityCardAppointments(GetIdentityCardAppointmentsQuery query)
        {
            var result = _dbContext.IdentityCardAppointments
                .ProjectTo<IdentityCardAppointmentResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateIdentityCardAppointment(UpdateIdentityCardAppointmentCommand command, CancellationToken cancellationToken)
        {
            var identityCardAppointment = _dbContext.IdentityCardAppointments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (identityCardAppointment != null)
            {
                throw new Exception("The identity card appointment does not exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);

            identityCardAppointment.AdditionalInformation = command.AdditionalInformation;
            identityCardAppointment.AppointmentDay = command.AppointmentDay;
            identityCardAppointment.Citizen = citizen;
            identityCardAppointment.Reason = command.Reason;

            _dbContext.IdentityCardAppointments.Update(identityCardAppointment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
