namespace GovernmentSystem.Application.Handlers.Regularizations.Queries
{
    public class GetRegularizationByIdQuery : IRequest<Result<RegularizationResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetRegularizationByIdQueryHandler : IRequestHandler<GetRegularizationByIdQuery, Result<RegularizationResponse>>
    {
        private readonly IRegularizationService _regularizationService;

        public GetRegularizationByIdQueryHandler(IRegularizationService regularizationService)
        {
            _regularizationService = regularizationService;
        }

        public Task<Result<RegularizationResponse>> Handle(GetRegularizationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _regularizationService.GetRegularizationById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<RegularizationResponse>
                {
                    Error = $"There was an error retrieving the regularization by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
