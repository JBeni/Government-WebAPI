using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityHallReportProblems.Commands
{
    public class UpdateCityHallReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }

    public class UpdateCityHallReportProblemCommandHandler : IRequestHandler<UpdateCityHallReportProblemCommand, RequestResponse>
    {
        private readonly ICityHallReportProblemService _cityHallReportProblemService;

        public UpdateCityHallReportProblemCommandHandler(ICityHallReportProblemService cityHallReportProblemService)
        {
            _cityHallReportProblemService = cityHallReportProblemService;
        }

        public async Task<RequestResponse> Handle(UpdateCityHallReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityHallReportProblemService.UpdateCityHallReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateCityHallReportProblemCommandValidator : AbstractValidator<UpdateCityHallReportProblemCommand>
    {
        public UpdateCityHallReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
            RuleFor(v => v.DateOfIssue).NotEmpty().NotNull();
            RuleFor(v => v.DateOfExpiry).NotEmpty().NotNull();
        }
    }
}
