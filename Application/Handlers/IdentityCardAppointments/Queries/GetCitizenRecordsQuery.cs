namespace GovernmentSystem.Application.Handlers.IdentityCardAppointments.Queries
{
    public class GetIdentityCardAppointmentsQuery : IRequest<List<IdentityCardAppointmentResponse>>
    {
    }

    public class GetIdentityCardAppointmentsQueryHandler : IRequestHandler<GetIdentityCardAppointmentsQuery, List<IdentityCardAppointmentResponse>>
    {
        private readonly IIdentityCardAppointmentService _identityCardAppointmentService;

        public GetIdentityCardAppointmentsQueryHandler(IIdentityCardAppointmentService identityCardAppointmentService)
        {
            _identityCardAppointmentService = identityCardAppointmentService;
        }

        public Task<List<IdentityCardAppointmentResponse>> Handle(GetIdentityCardAppointmentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _identityCardAppointmentService.GetIdentityCardAppointments(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the identity card appointments", ex);
            }
        }
    }
}
