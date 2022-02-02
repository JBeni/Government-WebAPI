namespace GovernmentSystem.Application.Handlers.CityReportProblems.Commands
{
    public class UpdateCityReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public Guid CityHallId { get; set; }
    }

    public class UpdateCityReportProblemCommandHandler : IRequestHandler<UpdateCityReportProblemCommand, RequestResponse>
    {
        private readonly ICityReportProblemService _cityReportProblemService;

        public UpdateCityReportProblemCommandHandler(ICityReportProblemService cityReportProblemService)
        {
            _cityReportProblemService = cityReportProblemService;
        }

        public async Task<RequestResponse> Handle(UpdateCityReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityReportProblemService.UpdateCityReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdateCityReportProblemCommandValidator : AbstractValidator<UpdateCityReportProblemCommand>
    {
        public UpdateCityReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
            RuleFor(v => v.DateOfIssue).NotEmpty().NotNull();
            RuleFor(v => v.DateOfExpiry).NotEmpty().NotNull();
            RuleFor(v => v.CityHallId).NotEmpty().NotNull();
        }
    }
}
