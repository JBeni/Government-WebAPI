using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.ReportProblems.Commands
{
    public class UpdateReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }

    public class UpdateReportProblemCommandHandler : IRequestHandler<UpdateReportProblemCommand, RequestResponse>
    {
        private readonly IReportProblemService _reportProblemService;

        public UpdateReportProblemCommandHandler(IReportProblemService reportProblemService)
        {
            _reportProblemService = reportProblemService;
        }

        public async Task<RequestResponse> Handle(UpdateReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _reportProblemService.UpdateReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateReportProblemCommandHandlerValidator : AbstractValidator<UpdateReportProblemCommand>
    {
        public UpdateReportProblemCommandHandlerValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
            RuleFor(v => v.DateOfExpiry).NotEmpty().NotNull();
        }
    }
}
