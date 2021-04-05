using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityReportProblems.Queries
{
    public class GetCityReportProblemByIdQuery : IRequest<CityReportProblemResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCityReportProblemByIdQueryHandler : IRequestHandler<GetCityReportProblemByIdQuery, CityReportProblemResponse>
    {
        private readonly ICityReportProblemService _cityReportProblemService;

        public GetCityReportProblemByIdQueryHandler(ICityReportProblemService cityReportProblemService)
        {
            _cityReportProblemService = cityReportProblemService;
        }

        public Task<CityReportProblemResponse> Handle(GetCityReportProblemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityReportProblemService.GetCityReportProblemById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the report problem by Id", ex);
            }
        }
    }
}
