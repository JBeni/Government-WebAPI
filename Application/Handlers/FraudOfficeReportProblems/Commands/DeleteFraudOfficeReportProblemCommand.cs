namespace GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Commands
{
    public class DeleteFraudOfficeReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteFraudOfficeReportProblemCommandHandler : IRequestHandler<DeleteFraudOfficeReportProblemCommand, RequestResponse>
    {
        private readonly IFraudOfficeReportProblemService _fraudOfficeReportProblemService;

        public DeleteFraudOfficeReportProblemCommandHandler(IFraudOfficeReportProblemService fraudOfficeReportProblemService)
        {
            _fraudOfficeReportProblemService = fraudOfficeReportProblemService;
        }

        public async Task<RequestResponse> Handle(DeleteFraudOfficeReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _fraudOfficeReportProblemService.DeleteFraudOfficeReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteFraudOfficeReportProblemCommandValidator : AbstractValidator<DeleteFraudOfficeReportProblemCommand>
    {
        public DeleteFraudOfficeReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
