namespace GovernmentSystem.Application.Handlers.CityPayments.Commands
{
    public class DeleteCityPaymentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteCityPaymentCommandHandler : IRequestHandler<DeleteCityPaymentCommand, RequestResponse>
    {
        private readonly ICityPaymentService _cityPaymentService;

        public DeleteCityPaymentCommandHandler(ICityPaymentService cityPaymentService)
        {
            _cityPaymentService = cityPaymentService;
        }

        public async Task<RequestResponse> Handle(DeleteCityPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityPaymentService.DeleteCityPayment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteCityPaymentCommandValidator : AbstractValidator<DeleteCityPaymentCommand>
    {
        public DeleteCityPaymentCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
