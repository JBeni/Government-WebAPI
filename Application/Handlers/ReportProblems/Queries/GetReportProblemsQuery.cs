using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.ReportProblems.Queries
{
    public class GetReportProblemsQuery : IRequest<List<ReportProblemsResponse>>
    {
        public string County { get; set; }
    }

    public class GetReportProblemsQueryHandler : IRequestHandler<GetReportProblemsQuery, List<ReportProblemsResponse>>
    {
        private readonly IReportProblemService _reportProblemservice;

        public GetReportProblemsQueryHandler(IReportProblemService reportProblemService)
        {
            _reportProblemservice = reportProblemService;
        }

        public Task<List<ReportProblemsResponse>> Handle(GetReportProblemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _reportProblemservice.GetReportProblems(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the report problems", ex);
            }
        }
    }

    public class ReportProblemsResponse : IMapFrom<ReportProblem>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<ReportProblem, ReportProblemsResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
