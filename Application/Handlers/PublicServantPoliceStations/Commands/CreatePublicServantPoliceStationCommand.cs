namespace GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Commands
{
    public class CreatePublicServantPoliceStationCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public Guid PoliceStationId { get; set; }
    }

    public class CreatePublicServantPoliceStationCommandHandler : IRequestHandler<CreatePublicServantPoliceStationCommand, RequestResponse>
    {
        private readonly IPublicServantPoliceStationService _publicServantPoliceService;

        public CreatePublicServantPoliceStationCommandHandler(IPublicServantPoliceStationService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public async Task<RequestResponse> Handle(CreatePublicServantPoliceStationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantPoliceService.CreatePublicServantPoliceStation(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePublicServantPoliceStationCommandValidator : AbstractValidator<CreatePublicServantPoliceStationCommand>
    {
        public CreatePublicServantPoliceStationCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.CNP).NotEmpty().NotNull();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.DutyRole).NotEmpty().NotNull();
            RuleFor(v => v.ContractYears).NotEmpty().NotNull();
            RuleFor(v => v.HireStartDate).NotEmpty().NotNull();
            RuleFor(v => v.HireEndDate).NotEmpty().NotNull();
            RuleFor(v => v.PoliceStationId).NotEmpty().NotNull();
        }
    }
}
