namespace GovernmentSystem.Infrastructure.Services
{
    public class CityPaymentService : ICityPaymentService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public CityPaymentService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateCityPayment(CreateCityPaymentCommand command, CancellationToken cancellationToken)
        {
            var cityPayment = _dbContext.CityPayments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityPayment != null)
            {
                throw new Exception("The city payment already exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);
            var invoice = _insideEntityService.GetInvoiceById(command.InvoiceId);

            var entity = new CityPayment
            {
                Title = command.Title,
                AmountPaid = command.AmountPaid,
                AmountToPay = command.AmountToPay,
                DateOfPayment = command.DateOfPayment,
                Citizen = citizen.Item,
                CityHall = cityHall.Item,
                Invoice = invoice.Item,
            };

            _dbContext.CityPayments.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteCityPayment(DeleteCityPaymentCommand command, CancellationToken cancellationToken)
        {
            var cityPayment = _dbContext.CityPayments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityPayment != null)
            {
                throw new Exception("The city payment does not exists");
            }

            _dbContext.CityPayments.Remove(cityPayment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(cityPayment.Identifier);
        }

        public Result<CityPaymentResponse> GetCityPaymentById(GetCityPaymentByIdQuery query)
        {
            var result = _dbContext.CityPayments
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<CityPaymentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<CityPaymentResponse> { Successful = true, Item = result ?? new CityPaymentResponse() };
        }

        public Result<CityPaymentResponse> GetCityPayments(GetCityPaymentsQuery query)
        {
            var result = _dbContext.CityPayments
                .ProjectTo<CityPaymentResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<CityPaymentResponse> { Successful = true, Items = result ?? new List<CityPaymentResponse>() };
        }

        public async Task<RequestResponse> UpdateCityPayment(UpdateCityPaymentCommand command, CancellationToken cancellationToken)
        {
            var cityPayment = _dbContext.CityPayments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityPayment != null)
            {
                throw new Exception("The city payment does not exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);
            var invoice = _insideEntityService.GetInvoiceById(command.InvoiceId);

            cityPayment.Title = command.Title;
            cityPayment.AmountPaid = command.AmountPaid;
            cityPayment.AmountToPay = command.AmountToPay;
            cityPayment.DateOfPayment = command.DateOfPayment;
            cityPayment.Citizen = citizen.Item;
            cityPayment.CityHall = cityHall.Item;
            cityPayment.Invoice = invoice.Item;

            _dbContext.CityPayments.Update(cityPayment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(cityPayment.Identifier);
        }
    }
}
