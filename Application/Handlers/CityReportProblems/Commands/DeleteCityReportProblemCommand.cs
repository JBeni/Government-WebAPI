﻿using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityReportProblems.Commands
{
    public class DeleteCityReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteCityReportProblemCommandHandler : IRequestHandler<DeleteCityReportProblemCommand, RequestResponse>
    {
        private readonly ICityReportProblemService _cityReportProblemService;

        public DeleteCityReportProblemCommandHandler(ICityReportProblemService cityReportProblemService)
        {
            _cityReportProblemService = cityReportProblemService;
        }

        public async Task<RequestResponse> Handle(DeleteCityReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityReportProblemService.DeleteCityReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteCityReportProblemCommandValidator : AbstractValidator<DeleteCityReportProblemCommand>
    {
        public DeleteCityReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
