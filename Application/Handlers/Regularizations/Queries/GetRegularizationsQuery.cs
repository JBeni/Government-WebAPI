namespace GovernmentSystem.Application.Handlers.Regularizations.Queries
{
    public class GetRegularizationsQuery : IRequest<Result<RegularizationResponse>>
    {
    }

    public class GetRegularizationsQueryHandler : IRequestHandler<GetRegularizationsQuery, Result<RegularizationResponse>>
    {
        private readonly IRegularizationService _regularizationService;

        public GetRegularizationsQueryHandler(IRegularizationService regularizationService)
        {
            _regularizationService = regularizationService;
        }

        public Task<Result<RegularizationResponse>> Handle(GetRegularizationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _regularizationService.GetRegularizations(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<RegularizationResponse>
                {
                    Error = $"There was an error retrieving the regularizations. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
