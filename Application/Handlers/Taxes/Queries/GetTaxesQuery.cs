namespace GovernmentSystem.Application.Handlers.Taxes.Queries
{
    public class GetTaxesQuery : IRequest<Result<TaxResponse>>
    {
    }

    public class GetTaxesQueryHandler : IRequestHandler<GetTaxesQuery, Result<TaxResponse>>
    {
        private readonly ITaxService _taxService;

        public GetTaxesQueryHandler(ITaxService taxService)
        {
            _taxService = taxService;
        }

        public Task<Result<TaxResponse>> Handle(GetTaxesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _taxService.GetTaxes(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the taxes", ex);
            }
        }
    }
}
