namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Commands
{
    public class UpdateMedicalProcedureCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public long Price { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureDuration { get; set; }
        public string AdditionalInformation { get; set; }
    }

    public class UpdateMedicalProceduresCommandHandler : IRequestHandler<UpdateMedicalProcedureCommand, RequestResponse>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public UpdateMedicalProceduresCommandHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public async Task<RequestResponse> Handle(UpdateMedicalProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalProcedureservice.UpdateMedicalProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateMedicalProcedureCommandValidator : AbstractValidator<UpdateMedicalProcedureCommand>
    {
        public UpdateMedicalProcedureCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Price).NotEmpty().NotNull();
            RuleFor(v => v.ProcedureName).NotEmpty().NotNull();
            RuleFor(v => v.ProcedureDuration).NotEmpty().NotNull();
            RuleFor(v => v.AdditionalInformation).NotEmpty().NotNull();
        }
    }
}
