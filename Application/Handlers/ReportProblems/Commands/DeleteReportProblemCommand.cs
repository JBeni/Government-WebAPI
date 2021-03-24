using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.ReportProblems.Commands
{
    public class DeleteReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteReportProblemCommandHandler : IRequestHandler<DeleteReportProblemCommand, RequestResponse>
    {
        private readonly IReportProblemService _reportProblemService;

        public DeleteReportProblemCommandHandler(IReportProblemService reportProblemService)
        {
            _reportProblemService = reportProblemService;
        }

        public async Task<RequestResponse> Handle(DeleteReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _reportProblemService.DeleteReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteReportProblemCommandValidator : AbstractValidator<DeleteReportProblemCommand>
    {
        public DeleteReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
