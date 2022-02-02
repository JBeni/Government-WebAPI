namespace GovernmentSystem.Infrastructure.Services
{
    public class PaymentHistoryService : IPaymentHistoryService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public PaymentHistoryService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreatePaymentHistory(CreatePaymentHistoryCommand command, CancellationToken cancellationToken)
        {
            var paymentHistory = _dbContext.PaymentHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (paymentHistory != null)
            {
                throw new Exception("The payment history already exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenWhoPaidId);
            var entity = new PaymentHistory
            {
                Title = command.Title,
                Description = command.Description,
                InstitutionType = command.InstitutionType,
                AmountToPay = command.AmountToPay,
                AmountPaid = command.AmountPaid,
                DateOfPayment = command.DateOfPayment,
                CitizenWhoPaid = citizen.Item,
            };

            _dbContext.PaymentHistories.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeletePaymentHistory(DeletePaymentHistoryCommand command, CancellationToken cancellationToken)
        {
            var paymentHistory = _dbContext.PaymentHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (paymentHistory == null)
            {
                throw new Exception("The payment history does not exists");
            }

            _dbContext.PaymentHistories.Remove(paymentHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(paymentHistory.Identifier);
        }

        public Result<PaymentHistoryResponse> GetPaymentHistoryById(GetPaymentHistoryByIdQuery query)
        {
            var result = _dbContext.PaymentHistories
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<PaymentHistoryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<PaymentHistoryResponse> { Successful = true, Item = result ?? new PaymentHistoryResponse() };
        }

        public Result<PaymentHistoryResponse> GetPaymentHistories(GetPaymentHistoriesQuery query)
        {
            var result = _dbContext.PaymentHistories
                .ProjectTo<PaymentHistoryResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<PaymentHistoryResponse> { Successful = true, Items = result ?? new List<PaymentHistoryResponse>() };
        }

        public async Task<RequestResponse> UpdatePaymentHistory(UpdatePaymentHistoryCommand command, CancellationToken cancellationToken)
        {
            var paymentHistory = _dbContext.PaymentHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (paymentHistory == null)
            {
                throw new Exception("The payment history does not exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenWhoPaidId);

            paymentHistory.Title = command.Title;
            paymentHistory.Description = command.Description;
            paymentHistory.InstitutionType = command.InstitutionType;
            paymentHistory.AmountToPay = command.AmountToPay;
            paymentHistory.AmountPaid = command.AmountPaid;
            paymentHistory.DateOfPayment = command.DateOfPayment;
            paymentHistory.CitizenWhoPaid = citizen.Item;

            _dbContext.PaymentHistories.Update(paymentHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(paymentHistory.Identifier);
        }
    }
}
