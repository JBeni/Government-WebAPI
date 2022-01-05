namespace GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Commands
{
    public class UpdateFraudOfficeReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public Guid SeriousFraudOfficeId { get; set; }
    }

    public class UpdateFraudOfficeReportProblemCommandHandler : IRequestHandler<UpdateFraudOfficeReportProblemCommand, RequestResponse>
    {
        private readonly IFraudOfficeReportProblemService _fraudOfficeReportProblemService;

        public UpdateFraudOfficeReportProblemCommandHandler(IFraudOfficeReportProblemService fraudOfficeReportProblemService)
        {
            _fraudOfficeReportProblemService = fraudOfficeReportProblemService;
        }

        public async Task<RequestResponse> Handle(UpdateFraudOfficeReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _fraudOfficeReportProblemService.UpdateFraudOfficeReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateFraudOfficeReportProblemCommandValidator : AbstractValidator<UpdateFraudOfficeReportProblemCommand>
    {
        public UpdateFraudOfficeReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
            RuleFor(v => v.SeriousFraudOfficeId).NotEmpty().NotNull();
        }
    }
}
