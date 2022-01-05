namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Commands
{
    public class DeleteMedicalProcedureCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteMedicalProceduresCommandHandler : IRequestHandler<DeleteMedicalProcedureCommand, RequestResponse>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public DeleteMedicalProceduresCommandHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public async Task<RequestResponse> Handle(DeleteMedicalProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalProcedureservice.DeleteMedicalProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteMedicalProcedureCommandValidator : AbstractValidator<DeleteMedicalProcedureCommand>
    {
        public DeleteMedicalProcedureCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
