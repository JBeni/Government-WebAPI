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
        public int Id { get; set; }
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
            RuleFor(v => v.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
