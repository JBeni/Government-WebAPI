namespace GovernmentSystem.Application.Handlers.PolicePayments.Queries
{
    public class GetPolicePaymentsQuery : IRequest<List<PolicePaymentResponse>>
    {
    }

    public class GetPolicePaymentsQueryHandler : IRequestHandler<GetPolicePaymentsQuery, List<PolicePaymentResponse>>
    {
        private readonly IPolicePaymentService _policePaymentService;

        public GetPolicePaymentsQueryHandler(IPolicePaymentService policePaymentService)
        {
            _policePaymentService = policePaymentService;
        }

        public Task<List<PolicePaymentResponse>> Handle(GetPolicePaymentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policePaymentService.GetPolicePayments(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the police payments", ex);
            }
        }
    }
}
