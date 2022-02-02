namespace GovernmentSystem.Application.Handlers.PolicePayments.Queries
{
    public class GetPolicePaymentsQuery : IRequest<Result<PolicePaymentResponse>>
    {
    }

    public class GetPolicePaymentsQueryHandler : IRequestHandler<GetPolicePaymentsQuery, Result<PolicePaymentResponse>>
    {
        private readonly IPolicePaymentService _policePaymentService;

        public GetPolicePaymentsQueryHandler(IPolicePaymentService policePaymentService)
        {
            _policePaymentService = policePaymentService;
        }

        public Task<Result<PolicePaymentResponse>> Handle(GetPolicePaymentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policePaymentService.GetPolicePayments(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PolicePaymentResponse>
                {
                    Error = $"There was an error retrieving the police payments. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
