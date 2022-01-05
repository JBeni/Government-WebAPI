namespace GovernmentSystem.Application.Handlers.PoliceReportProblems.Commands
{
    public class DeletePoliceReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePoliceReportProblemCommandHandler : IRequestHandler<DeletePoliceReportProblemCommand, RequestResponse>
    {
        private readonly IPoliceReportProblemService _policeReportProblemService;

        public DeletePoliceReportProblemCommandHandler(IPoliceReportProblemService policeReportProblemService)
        {
            _policeReportProblemService = policeReportProblemService;
        }

        public async Task<RequestResponse> Handle(DeletePoliceReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _policeReportProblemService.DeletePoliceReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePoliceReportProblemCommandValidator : AbstractValidator<DeletePoliceReportProblemCommand>
    {
        public DeletePoliceReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
