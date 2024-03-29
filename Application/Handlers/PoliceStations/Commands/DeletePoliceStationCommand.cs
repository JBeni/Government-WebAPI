﻿namespace GovernmentSystem.Application.Handlers.PoliceStations.Commands
{
    public class DeletePoliceStationCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePoliceStationsCommandHandler : IRequestHandler<DeletePoliceStationCommand, RequestResponse>
    {
        private readonly IPoliceStationService _policeStationService;

        public DeletePoliceStationsCommandHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public async Task<RequestResponse> Handle(DeletePoliceStationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _policeStationService.DeletePoliceStation(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeletePoliceStationCommandValidator : AbstractValidator<DeletePoliceStationCommand>
    {
        public DeletePoliceStationCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
