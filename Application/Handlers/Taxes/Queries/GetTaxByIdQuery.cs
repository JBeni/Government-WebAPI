namespace GovernmentSystem.Application.Handlers.Taxes.Queries
{
    public class GetTaxByIdQuery : IRequest<Result<TaxResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetTaxByIdQueryHandler : IRequestHandler<GetTaxByIdQuery, Result<TaxResponse>>
    {
        private readonly ITaxService _taxService;

        public GetTaxByIdQueryHandler(ITaxService taxService)
        {
            _taxService = taxService;
        }

        public Task<Result<TaxResponse>> Handle(GetTaxByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _taxService.GetTaxById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the tax by Id", ex);
            }
        }
    }
}
