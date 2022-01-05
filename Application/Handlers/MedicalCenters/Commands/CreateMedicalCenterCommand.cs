namespace GovernmentSystem.Application.Handlers.MedicalCenters.Commands
{
    public class CreateMedicalCenterCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CenterName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Guid AddressId { get; set; }
    }

    public class CreateMedicalCentersCommandHandler : IRequestHandler<CreateMedicalCenterCommand, RequestResponse>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public CreateMedicalCentersCommandHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public async Task<RequestResponse> Handle(CreateMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterService.CreateMedicalCenter(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateMedicalCenterCommandValidator : AbstractValidator<CreateMedicalCenterCommand>
    {
        public CreateMedicalCenterCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.CenterName).NotEmpty().NotNull();
            RuleFor(v => v.ConstructionDate).NotEmpty().NotNull();
            RuleFor(v => v.AddressId).NotEmpty().NotNull();
        }
    }
}
