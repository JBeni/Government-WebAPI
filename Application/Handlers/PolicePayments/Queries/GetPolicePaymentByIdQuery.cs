namespace GovernmentSystem.Application.Handlers.PolicePayments.Queries
{
    public class GetPolicePaymentByIdQuery : IRequest<Result<PolicePaymentResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPolicePaymentByIdQueryHandler : IRequestHandler<GetPolicePaymentByIdQuery, Result<PolicePaymentResponse>>
    {
        private readonly IPolicePaymentService _policePaymentService;

        public GetPolicePaymentByIdQueryHandler(IPolicePaymentService policePaymentService)
        {
            _policePaymentService = policePaymentService;
        }

        public Task<Result<PolicePaymentResponse>> Handle(GetPolicePaymentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policePaymentService.GetPolicePaymentById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PolicePaymentResponse>
                {
                    Error = $"There was an error retrieving the police payment by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
