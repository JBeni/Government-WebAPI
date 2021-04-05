using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityHallReportProblems.Queries
{
    public class GetCityHallReportProblemByIdQuery : IRequest<CityHallReportProblemResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCityHallReportProblemByIdQueryHandler : IRequestHandler<GetCityHallReportProblemByIdQuery, CityHallReportProblemResponse>
    {
        private readonly ICityHallReportProblemService _cityHallReportProblemService;

        public GetCityHallReportProblemByIdQueryHandler(ICityHallReportProblemService cityHallReportProblemService)
        {
            _cityHallReportProblemService = cityHallReportProblemService;
        }

        public Task<CityHallReportProblemResponse> Handle(GetCityHallReportProblemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityHallReportProblemService.GetCityHallReportProblemById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the report problem by Id", ex);
            }
        }
    }
}
