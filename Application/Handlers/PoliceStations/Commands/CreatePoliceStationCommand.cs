﻿namespace GovernmentSystem.Application.Handlers.PoliceStations.Commands
{
    public class CreatePoliceStationCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string StationName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Guid AddressId { get; set; }
        public Guid CityHallId { get; set; }
    }

    public class CreatePoliceStationsCommandHandler : IRequestHandler<CreatePoliceStationCommand, RequestResponse>
    {
        private readonly IPoliceStationService _policeStationService;

        public CreatePoliceStationsCommandHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public async Task<RequestResponse> Handle(CreatePoliceStationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _policeStationService.CreatePoliceStation(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreatePoliceStationCommandValidator : AbstractValidator<CreatePoliceStationCommand>
    {
        public CreatePoliceStationCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.StationName).NotEmpty().NotNull();
            RuleFor(v => v.ConstructionDate).NotEmpty().NotNull();
            RuleFor(v => v.AddressId).NotEmpty().NotNull();
            RuleFor(v => v.CityHallId).NotEmpty().NotNull();
        }
    }
}
