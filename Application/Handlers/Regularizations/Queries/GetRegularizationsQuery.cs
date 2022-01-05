namespace GovernmentSystem.Application.Handlers.Regularizations.Queries
{
    public class GetRegularizationsQuery : IRequest<List<RegularizationResponse>>
    {
    }

    public class GetRegularizationsQueryHandler : IRequestHandler<GetRegularizationsQuery, List<RegularizationResponse>>
    {
        private readonly IRegularizationService _regularizationService;

        public GetRegularizationsQueryHandler(IRegularizationService regularizationService)
        {
            _regularizationService = regularizationService;
        }

        public Task<List<RegularizationResponse>> Handle(GetRegularizationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _regularizationService.GetRegularizations(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the regularizations", ex);
            }
        }
    }
}
