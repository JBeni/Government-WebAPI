namespace GovernmentSystem.Infrastructure.Services
{
    public class TaxService : ITaxService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public TaxService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateTax(CreateTaxCommand command, CancellationToken cancellationToken)
        {
            var Tax = _dbContext.Taxes.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (Tax != null)
            {
                throw new Exception("The tax already exists");
            }
            var company = _insideEntityService.GetCompanyById(command.CompanyId);
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);

            var entity = new Tax
            {
                Title = command.Title,
                Description = command.Description,
                AmountToPay = command.AmountToPay,
                AmountPaid = command.AmountPaid,
                Company = company.Item,
                Citizen = citizen.Item,
            };

            _dbContext.Taxes.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteTax(DeleteTaxCommand command, CancellationToken cancellationToken)
        {
            var Tax = _dbContext.Taxes.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (Tax == null)
            {
                throw new Exception("The tax does not exists");
            }

            _dbContext.Taxes.Remove(Tax);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(Tax.Identifier);
        }

        public Result<TaxResponse> GetTaxById(GetTaxByIdQuery query)
        {
            var result = _dbContext.Taxes
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<TaxResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

            return new Result<TaxResponse>
            {
                Successful = true,
                Item = result ?? new TaxResponse()
            };
        }

        public Result<TaxResponse> GetTaxes(GetTaxesQuery query)
        {
            var result = _dbContext.Taxes
                .ProjectTo<TaxResponse>(_mapper.ConfigurationProvider)
                .ToList();

            return new Result<TaxResponse>
            {
                Successful = true,
                Items = result ?? new List<TaxResponse>()
            };
        }

        public async Task<RequestResponse> UpdateTax(UpdateTaxCommand command, CancellationToken cancellationToken)
        {
            var Tax = _dbContext.Taxes.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (Tax == null)
            {
                throw new Exception("The tax does not exists");
            }
            var company = _insideEntityService.GetCompanyById(command.CompanyId);
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);

            Tax.Title = command.Title;
            Tax.Description = command.Description;
            Tax.AmountToPay = command.AmountToPay;
            Tax.AmountPaid = command.AmountPaid;
            Tax.Company = company.Item;
            Tax.Citizen = citizen.Item;

            _dbContext.Taxes.Update(Tax);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(Tax.Identifier);
        }
    }
}
