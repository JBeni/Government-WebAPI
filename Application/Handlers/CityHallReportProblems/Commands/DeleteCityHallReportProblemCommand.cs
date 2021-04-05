using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityHallReportProblems.Commands
{
    public class DeleteCityHallReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteCityHallReportProblemCommandHandler : IRequestHandler<DeleteCityHallReportProblemCommand, RequestResponse>
    {
        private readonly ICityHallReportProblemService _cityHallReportProblemService;

        public DeleteCityHallReportProblemCommandHandler(ICityHallReportProblemService cityHallReportProblemService)
        {
            _cityHallReportProblemService = cityHallReportProblemService;
        }

        public async Task<RequestResponse> Handle(DeleteCityHallReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityHallReportProblemService.DeleteCityHallReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteCityHallReportProblemCommandValidator : AbstractValidator<DeleteCityHallReportProblemCommand>
    {
        public DeleteCityHallReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
