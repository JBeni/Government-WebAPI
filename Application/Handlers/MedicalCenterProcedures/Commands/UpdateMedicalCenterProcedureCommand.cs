namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Commands
{
    public class UpdateMedicalCenterProcedureCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public Guid MedicalCenterId { get; set; }
        public Guid MedicalProcedureId { get; set; }
    }

    public class UpdateMedicalCenterProcedureCommandHandler : IRequestHandler<UpdateMedicalCenterProcedureCommand, RequestResponse>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public UpdateMedicalCenterProcedureCommandHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public async Task<RequestResponse> Handle(UpdateMedicalCenterProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterProcedureService.UpdateMedicalCenterProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateMedicalCenterProcedureCommandValidator : AbstractValidator<UpdateMedicalCenterProcedureCommand>
    {
        public UpdateMedicalCenterProcedureCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalProcedureId).NotEmpty().NotNull();
        }
    }
}
