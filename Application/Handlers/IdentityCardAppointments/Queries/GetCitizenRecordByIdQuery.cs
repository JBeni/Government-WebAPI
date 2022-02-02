namespace GovernmentSystem.Application.Handlers.IdentityCardAppointments.Queries
{
    public class GetIdentityCardAppointmentByIdQuery : IRequest<Result<IdentityCardAppointmentResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetIdentityCardAppointmentByIdQueryHandler : IRequestHandler<GetIdentityCardAppointmentByIdQuery, Result<IdentityCardAppointmentResponse>>
    {
        private readonly IIdentityCardAppointmentService _identityCardAppointmentService;

        public GetIdentityCardAppointmentByIdQueryHandler(IIdentityCardAppointmentService identityCardAppointmentService)
        {
            _identityCardAppointmentService = identityCardAppointmentService;
        }

        public Task<Result<IdentityCardAppointmentResponse>> Handle(GetIdentityCardAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _identityCardAppointmentService.GetIdentityCardAppointmentById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<IdentityCardAppointmentResponse>
                {
                    Error = $"There was an error retrieving the identity card appointment by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
