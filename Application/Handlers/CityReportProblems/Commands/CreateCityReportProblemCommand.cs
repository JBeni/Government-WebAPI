using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityReportProblems.Commands
{
    public class CreateCityReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public Guid CityHallId { get; set; }
    }

    public class CreateCityReportProblemCommandHandler : IRequestHandler<CreateCityReportProblemCommand, RequestResponse>
    {
        private readonly ICityReportProblemService _cityReportProblemService;

        public CreateCityReportProblemCommandHandler(ICityReportProblemService cityReportProblemService)
        {
            _cityReportProblemService = cityReportProblemService;
        }

        public async Task<RequestResponse> Handle(CreateCityReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityReportProblemService.CreateCityReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateCityReportProblemCommandValidator : AbstractValidator<CreateCityReportProblemCommand>
    {
        public CreateCityReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
            RuleFor(v => v.DateOfIssue).NotEmpty().NotNull();
            RuleFor(v => v.DateOfExpiry).Null();
            RuleFor(v => v.CityHallId).NotEmpty().NotNull();
        }
    }
}
