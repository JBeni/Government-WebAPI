namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Commands
{
    public class CreateMedicalProcedureCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public long Price { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureDuration { get; set; }
        public string AdditionalInformation { get; set; }
    }

    public class CreateMedicalProceduresCommandHandler : IRequestHandler<CreateMedicalProcedureCommand, RequestResponse>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public CreateMedicalProceduresCommandHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public async Task<RequestResponse> Handle(CreateMedicalProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalProcedureservice.CreateMedicalProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateMedicalProcedureCommandValidator : AbstractValidator<CreateMedicalProcedureCommand>
    {
        public CreateMedicalProcedureCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Price).NotEmpty().NotNull();
            RuleFor(v => v.ProcedureName).NotEmpty().NotNull();
            RuleFor(v => v.ProcedureDuration).NotEmpty().NotNull();
            RuleFor(v => v.AdditionalInformation).NotEmpty().NotNull();
        }
    }
}
