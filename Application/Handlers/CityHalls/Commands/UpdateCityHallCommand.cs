namespace GovernmentSystem.Application.Handlers.CityHalls.Commands
{
    public class UpdateCityHallCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CityHallName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Guid AddressId { get; set; }
    }

    public class UpdateCityHallCommandHandler : IRequestHandler<UpdateCityHallCommand, RequestResponse>
    {
        private readonly ICityHallService _cityHallService;

        public UpdateCityHallCommandHandler(ICityHallService cityHallService)
        {
            _cityHallService = cityHallService;
        }

        public async Task<RequestResponse> Handle(UpdateCityHallCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityHallService.UpdateCityHall(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdateCityHallCommandValidator : AbstractValidator<UpdateCityHallCommand>
    {
        public UpdateCityHallCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.CityHallName).NotEmpty().NotNull();
            RuleFor(v => v.ConstructionDate).NotEmpty().NotNull();
            RuleFor(v => v.AddressId).NotEmpty().NotNull();

        }
    }
}
