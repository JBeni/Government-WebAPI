﻿namespace GovernmentSystem.Application.Handlers.SeriousFraudOffices.Commands
{
    public class CreateSeriousFraudOfficeCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string OfficeName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Guid AddressId { get; set; }
    }

    public class CreateSeriousFraudOfficeCommandHandler : IRequestHandler<CreateSeriousFraudOfficeCommand, RequestResponse>
    {
        private readonly ISeriousFraudOfficeService _seriousFraudOfficeService;

        public CreateSeriousFraudOfficeCommandHandler(ISeriousFraudOfficeService seriousFraudOfficeService)
        {
            _seriousFraudOfficeService = seriousFraudOfficeService;
        }

        public async Task<RequestResponse> Handle(CreateSeriousFraudOfficeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _seriousFraudOfficeService.CreateSeriousFraudOffice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreateSeriousFraudOfficeCommandValidator : AbstractValidator<CreateSeriousFraudOfficeCommand>
    {
        public CreateSeriousFraudOfficeCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.OfficeName).NotEmpty().NotNull();
            RuleFor(v => v.ConstructionDate).NotEmpty().NotNull();
            RuleFor(v => v.AddressId).NotEmpty().NotNull();
        }
    }
}
