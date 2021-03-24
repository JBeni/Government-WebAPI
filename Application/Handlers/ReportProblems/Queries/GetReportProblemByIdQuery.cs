using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.ReportProblems.Queries
{
    public class GetReportProblemByIdQuery : IRequest<ReportProblemByIdResponse>
    {
        public string County { get; set; }
    }

    public class GetReportProblemByIdQueryHandler : IRequestHandler<GetReportProblemByIdQuery, ReportProblemByIdResponse>
    {
        private readonly IReportProblemService _reportProblemService;

        public GetReportProblemByIdQueryHandler(IReportProblemService reportProblemService)
        {
            _reportProblemService = reportProblemService;
        }

        public Task<ReportProblemByIdResponse> Handle(GetReportProblemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _reportProblemService.GetReportProblemById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the report problem by Id", ex);
            }
        }
    }

    public class ReportProblemByIdResponse : IMapFrom<ReportProblem>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<ReportProblem, ReportProblemByIdResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
