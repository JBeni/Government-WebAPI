namespace GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Commands
{
    public class DeletePublicServantPoliceStationCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePublicServantPoliceStationCommandHandler : IRequestHandler<DeletePublicServantPoliceStationCommand, RequestResponse>
    {
        private readonly IPublicServantPoliceStationService _publicServantPoliceService;

        public DeletePublicServantPoliceStationCommandHandler(IPublicServantPoliceStationService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public async Task<RequestResponse> Handle(DeletePublicServantPoliceStationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantPoliceService.DeletePublicServantPoliceStation(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePublicServantPoliceStationCommandValidator : AbstractValidator<DeletePublicServantPoliceStationCommand>
    {
        public DeletePublicServantPoliceStationCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
