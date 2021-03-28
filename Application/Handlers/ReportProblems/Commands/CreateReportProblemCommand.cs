using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.ReportProblems.Commands
{
    public class CreateReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }

    public class CreateReportProblemCommandHandler : IRequestHandler<CreateReportProblemCommand, RequestResponse>
    {
        private readonly IReportProblemService _reportProblemService;

        public CreateReportProblemCommandHandler(IReportProblemService reportProblemService)
        {
            _reportProblemService = reportProblemService;
        }

        public async Task<RequestResponse> Handle(CreateReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _reportProblemService.CreateReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateReportProblemCommandValidator : AbstractValidator<CreateReportProblemCommand>
    {
        public CreateReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
        }
    }
}
