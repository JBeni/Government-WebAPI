namespace GovernmentSystem.Application.Handlers.CityPayments.Commands
{
    public class CreateCityPaymentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public long AmountPaid { get; set; }
        public long AmountToPay { get; set; }
        public DateTime DateOfPayment { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid CityHallId { get; set; }
        public Guid CitizenId { get; set; }
    }

    public class CreateCityPaymentCommandHandler : IRequestHandler<CreateCityPaymentCommand, RequestResponse>
    {
        private readonly ICityPaymentService _cityPaymentService;

        public CreateCityPaymentCommandHandler(ICityPaymentService cityPaymentService)
        {
            _cityPaymentService = cityPaymentService;
        }

        public async Task<RequestResponse> Handle(CreateCityPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityPaymentService.CreateCityPayment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateCityPaymentCommandValidator : AbstractValidator<CreateCityPaymentCommand>
    {
        public CreateCityPaymentCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.AmountPaid).NotEmpty().NotNull();
            RuleFor(v => v.AmountToPay).NotEmpty().NotNull();
            RuleFor(v => v.DateOfPayment).NotEmpty().NotNull();
            RuleFor(v => v.InvoiceId).NotEmpty().NotNull();
            RuleFor(v => v.CityHallId).NotEmpty().NotNull();
            RuleFor(v => v.CitizenId).NotEmpty().NotNull();
        }
    }
}
