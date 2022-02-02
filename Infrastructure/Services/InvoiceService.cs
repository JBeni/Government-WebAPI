namespace GovernmentSystem.Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public InvoiceService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateInvoice(CreateInvoiceCommand command, CancellationToken cancellationToken)
        {
            var invoice = _dbContext.Invoices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (invoice != null)
            {
                throw new Exception("The invoice already exists");
            }
            var entity = new Invoice
            {
                Title = command.Title,
                Description = command.Description,
                InstitutionType = command.InstitutionType,
                AmountToPay = command.AmountToPay,
                IssuedDate = command.IssuedDate,
                DueDate = command.DueDate,
            };

            _dbContext.Invoices.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteInvoice(DeleteInvoiceCommand command, CancellationToken cancellationToken)
        {
            var invoice = _dbContext.Invoices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (invoice == null)
            {
                throw new Exception("The invoice does not exists");
            }

            _dbContext.Invoices.Remove(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(invoice.Identifier);
        }

        public Result<InvoiceResponse> GetInvoiceById(GetInvoiceByIdQuery query)
        {
            var result = _dbContext.Invoices
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<InvoiceResponse> { Successful = true, Item = result ?? new InvoiceResponse() };
        }

        public Result<InvoiceResponse> GetInvoices(GetInvoicesQuery query)
        {
            var result = _dbContext.Invoices
                .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<InvoiceResponse> { Successful = true, Items = result ?? new List<InvoiceResponse>() };
        }

        public async Task<RequestResponse> UpdateInvoice(UpdateInvoiceCommand command, CancellationToken cancellationToken)
        {
            var invoice = _dbContext.Invoices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (invoice == null)
            {
                throw new Exception("The invoice does not exists");
            }
            invoice.Title = command.Title;
            invoice.Description = command.Description;
            invoice.InstitutionType = command.InstitutionType;
            invoice.AmountToPay = command.AmountToPay;
            invoice.IssuedDate = command.IssuedDate;
            invoice.DueDate = command.DueDate;

            _dbContext.Invoices.Update(invoice);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(invoice.Identifier);
        }
    }
}
