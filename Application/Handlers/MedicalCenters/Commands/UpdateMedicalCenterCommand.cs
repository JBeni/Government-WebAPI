namespace GovernmentSystem.Application.Handlers.MedicalCenters.Commands
{
    public class UpdateMedicalCenterCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CenterName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Guid AddressId { get; set; }
    }

    public class UpdateMedicalCenterCommandHandler : IRequestHandler<UpdateMedicalCenterCommand, RequestResponse>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public UpdateMedicalCenterCommandHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public async Task<RequestResponse> Handle(UpdateMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterService.UpdateMedicalCenter(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateMedicalCenterCommandValidator : AbstractValidator<UpdateMedicalCenterCommand>
    {
        public UpdateMedicalCenterCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.CenterName).NotEmpty().NotNull();
            RuleFor(v => v.ConstructionDate).NotEmpty().NotNull();
            RuleFor(v => v.AddressId).NotEmpty().NotNull();
        }
    }
}
