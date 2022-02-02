namespace GovernmentSystem.Infrastructure.Services
{
    public class PolicePaymentService : IPolicePaymentService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public PolicePaymentService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreatePolicePayment(CreatePolicePaymentCommand command, CancellationToken cancellationToken)
        {
            var policePayment = _dbContext.PolicePayments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (policePayment != null)
            {
                throw new Exception("The police payment already exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var policeStation = _insideEntityService.GetPoliceStationById(command.PoliceStationId);
            var invoice = _insideEntityService.GetInvoiceById(command.InvoiceId);

            var entity = new PolicePayment
            {
                Title = command.Title,
                AmountPaid = command.AmountPaid,
                AmountToPay = command.AmountToPay,
                DateOfPayment = command.DateOfPayment,
                Citizen = citizen.Item,
                PoliceStation = policeStation.Item,
                Invoice = invoice.Item,
            };

            _dbContext.PolicePayments.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeletePolicePayment(DeletePolicePaymentCommand command, CancellationToken cancellationToken)
        {
            var policePayment = _dbContext.PolicePayments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (policePayment != null)
            {
                throw new Exception("The police payment does not exists");
            }

            _dbContext.PolicePayments.Remove(policePayment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(policePayment.Identifier);
        }

        public Result<PolicePaymentResponse> GetPolicePaymentById(GetPolicePaymentByIdQuery query)
        {
            var result = _dbContext.PolicePayments
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PolicePaymentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<PolicePaymentResponse> { Successful = true, Item = result ?? new PolicePaymentResponse() };
        }

        public Result<PolicePaymentResponse> GetPolicePayments(GetPolicePaymentsQuery query)
        {
            var result = _dbContext.PolicePayments
                .ProjectTo<PolicePaymentResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<PolicePaymentResponse> { Successful = true, Items = result ?? new List<PolicePaymentResponse>() };
        }

        public async Task<RequestResponse> UpdatePolicePayment(UpdatePolicePaymentCommand command, CancellationToken cancellationToken)
        {
            var policePayment = _dbContext.PolicePayments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (policePayment != null)
            {
                throw new Exception("The police payment does not exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var policeStation = _insideEntityService.GetPoliceStationById(command.PoliceStationId);
            var invoice = _insideEntityService.GetInvoiceById(command.InvoiceId);

            policePayment.Title = command.Title;
            policePayment.AmountPaid = command.AmountPaid;
            policePayment.AmountToPay = command.AmountToPay;
            policePayment.DateOfPayment = command.DateOfPayment;
            policePayment.Citizen = citizen.Item;
            policePayment.PoliceStation = policeStation.Item;
            policePayment.Invoice = invoice.Item;

            _dbContext.PolicePayments.Update(policePayment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(policePayment.Identifier);
        }
    }
}
