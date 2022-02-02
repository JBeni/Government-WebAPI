namespace GovernmentSystem.Application.Handlers.PoliceReportProblems.Commands
{
    public class UpdatePoliceReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public Guid PoliceStationId { get; set; }
    }

    public class UpdatePoliceReportProblemCommandHandler : IRequestHandler<UpdatePoliceReportProblemCommand, RequestResponse>
    {
        private readonly IPoliceReportProblemService _policeReportProblemService;

        public UpdatePoliceReportProblemCommandHandler(IPoliceReportProblemService policeReportProblemService)
        {
            _policeReportProblemService = policeReportProblemService;
        }

        public async Task<RequestResponse> Handle(UpdatePoliceReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _policeReportProblemService.UpdatePoliceReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdatePoliceReportProblemCommandValidator : AbstractValidator<UpdatePoliceReportProblemCommand>
    {
        public UpdatePoliceReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
            RuleFor(v => v.PoliceStationId).NotEmpty().NotNull();
        }
    }
}
