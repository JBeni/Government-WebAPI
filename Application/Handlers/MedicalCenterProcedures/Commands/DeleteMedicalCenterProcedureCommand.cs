namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Commands
{
    public class DeleteMedicalCenterProcedureCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteMedicalCenterProcedureCommandHandler : IRequestHandler<DeleteMedicalCenterProcedureCommand, RequestResponse>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public DeleteMedicalCenterProcedureCommandHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public async Task<RequestResponse> Handle(DeleteMedicalCenterProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterProcedureService.DeleteMedicalCenterProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteMedicalCenterProcedureCommandValidator : AbstractValidator<DeleteMedicalCenterProcedureCommand>
    {
        public DeleteMedicalCenterProcedureCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
