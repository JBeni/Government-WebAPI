namespace GovernmentSystem.Application.Handlers.MedicalCenters.Commands
{
    public class DeleteMedicalCenterCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteMedicalCenterCommandHandler : IRequestHandler<DeleteMedicalCenterCommand, RequestResponse>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public DeleteMedicalCenterCommandHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public async Task<RequestResponse> Handle(DeleteMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterService.DeleteMedicalCenter(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteMedicalCenterCommandValidator : AbstractValidator<DeleteMedicalCenterCommand>
    {
        public DeleteMedicalCenterCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
