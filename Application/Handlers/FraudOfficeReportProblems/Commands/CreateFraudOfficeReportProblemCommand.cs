namespace GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Commands
{
    public class CreateFraudOfficeReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public Guid SeriousFraudOfficeId { get; set; }
    }

    public class CreateFraudOfficeReportProblemCommandHandler : IRequestHandler<CreateFraudOfficeReportProblemCommand, RequestResponse>
    {
        private readonly IFraudOfficeReportProblemService _fraudOfficeReportProblemService;

        public CreateFraudOfficeReportProblemCommandHandler(IFraudOfficeReportProblemService fraudOfficeReportProblemService)
        {
            _fraudOfficeReportProblemService = fraudOfficeReportProblemService;
        }

        public async Task<RequestResponse> Handle(CreateFraudOfficeReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _fraudOfficeReportProblemService.CreateFraudOfficeReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateFraudOfficeReportProblemCommandValidator : AbstractValidator<CreateFraudOfficeReportProblemCommand>
    {
        public CreateFraudOfficeReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
            RuleFor(v => v.SeriousFraudOfficeId).NotEmpty().NotNull();
        }
    }
}
