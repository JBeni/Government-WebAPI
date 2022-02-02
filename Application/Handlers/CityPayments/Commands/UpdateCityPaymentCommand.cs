namespace GovernmentSystem.Application.Handlers.CityPayments.Commands
{
    public class UpdateCityPaymentCommand : IRequest<RequestResponse>
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

    public class UpdateCityPaymentCommandHandler : IRequestHandler<UpdateCityPaymentCommand, RequestResponse>
    {
        private readonly ICityPaymentService _cityPaymentService;

        public UpdateCityPaymentCommandHandler(ICityPaymentService cityPaymentService)
        {
            _cityPaymentService = cityPaymentService;
        }

        public async Task<RequestResponse> Handle(UpdateCityPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityPaymentService.UpdateCityPayment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdateCityPaymentCommandValidator : AbstractValidator<UpdateCityPaymentCommand>
    {
        public UpdateCityPaymentCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
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
