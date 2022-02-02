namespace GovernmentSystem.Application.Handlers.IdentityCardAppointments.Queries
{
    public class GetIdentityCardAppointmentsQuery : IRequest<Result<IdentityCardAppointmentResponse>>
    {
    }

    public class GetIdentityCardAppointmentsQueryHandler : IRequestHandler<GetIdentityCardAppointmentsQuery, Result<IdentityCardAppointmentResponse>>
    {
        private readonly IIdentityCardAppointmentService _identityCardAppointmentService;

        public GetIdentityCardAppointmentsQueryHandler(IIdentityCardAppointmentService identityCardAppointmentService)
        {
            _identityCardAppointmentService = identityCardAppointmentService;
        }

        public Task<Result<IdentityCardAppointmentResponse>> Handle(GetIdentityCardAppointmentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _identityCardAppointmentService.GetIdentityCardAppointments(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<IdentityCardAppointmentResponse>
                {
                    Error = $"There was an error retrieving the identity card appointments. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
