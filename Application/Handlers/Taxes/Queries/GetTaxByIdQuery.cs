namespace GovernmentSystem.Application.Handlers.Taxes.Queries
{
    public class GetTaxByIdQuery : IRequest<TaxResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetTaxByIdQueryHandler : IRequestHandler<GetTaxByIdQuery, TaxResponse>
    {
        private readonly ITaxService _taxService;

        public GetTaxByIdQueryHandler(ITaxService taxService)
        {
            _taxService = taxService;
        }

        public Task<TaxResponse> Handle(GetTaxByIdQuery request, CancellationToken cancellationToken)
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
