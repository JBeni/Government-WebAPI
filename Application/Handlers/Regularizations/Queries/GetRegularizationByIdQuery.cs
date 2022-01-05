namespace GovernmentSystem.Application.Handlers.Regularizations.Queries
{
    public class GetRegularizationByIdQuery : IRequest<RegularizationResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetRegularizationByIdQueryHandler : IRequestHandler<GetRegularizationByIdQuery, RegularizationResponse>
    {
        private readonly IRegularizationService _regularizationService;

        public GetRegularizationByIdQueryHandler(IRegularizationService regularizationService)
        {
            _regularizationService = regularizationService;
        }

        public Task<RegularizationResponse> Handle(GetRegularizationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _regularizationService.GetRegularizationById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the regularization by Id", ex);
            }
        }
    }
}
