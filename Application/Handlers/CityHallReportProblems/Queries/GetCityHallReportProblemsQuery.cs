using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityHallReportProblems.Queries
{
    public class GetCityHallReportProblemsQuery : IRequest<List<CityHallReportProblemResponse>>
    {
    }

    public class GetCityHallReportProblemsQueryHandler : IRequestHandler<GetCityHallReportProblemsQuery, List<CityHallReportProblemResponse>>
    {
        private readonly ICityHallReportProblemService _cityHallReportProblemService;

        public GetCityHallReportProblemsQueryHandler(ICityHallReportProblemService cityHallReportProblemService)
        {
            _cityHallReportProblemService = cityHallReportProblemService;
        }

        public Task<List<CityHallReportProblemResponse>> Handle(GetCityHallReportProblemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityHallReportProblemService.GetCityHallReportProblems(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the report problems", ex);
            }
        }
    }
}
