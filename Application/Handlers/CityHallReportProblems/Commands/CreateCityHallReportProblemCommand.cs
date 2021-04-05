using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityHallReportProblems.Commands
{
    public class CreateCityHallReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }

    public class CreateCityHallReportProblemCommandHandler : IRequestHandler<CreateCityHallReportProblemCommand, RequestResponse>
    {
        private readonly ICityHallReportProblemService _cityHallReportProblemService;

        public CreateCityHallReportProblemCommandHandler(ICityHallReportProblemService cityHallReportProblemService)
        {
            _cityHallReportProblemService = cityHallReportProblemService;
        }

        public async Task<RequestResponse> Handle(CreateCityHallReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityHallReportProblemService.CreateCityHallReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateCityHallReportProblemCommandValidator : AbstractValidator<CreateCityHallReportProblemCommand>
    {
        public CreateCityHallReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
            RuleFor(v => v.DateOfIssue).NotEmpty().NotNull();
            RuleFor(v => v.DateOfExpiry).Null();
        }
    }
}
