using GovernmentSystem.Application.Handlers.ReportProblems.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Application.Handlers.ReportProblems.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace GovernmentSystem.Infrastructure.Services
{
    public class ReportProblemService : IReportProblemService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReportProblemService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateReportProblem(CreateReportProblemCommand command, CancellationToken cancellationToken)
        {
            var reportProblem = _dbContext.ReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (reportProblem != null)
            {
                throw new Exception("The reported problem already exists");
            }
            var entity = new ReportProblem
            {
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
                Description = command.Description,
                IsProcessed = false,
                Title = command.Title
            };

            _dbContext.ReportProblems.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteReportProblem(DeleteReportProblemCommand command, CancellationToken cancellationToken)
        {
            var reportProblem = _dbContext.ReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (reportProblem == null)
            {
                throw new Exception("The reported problem does not exists");
            }

            _dbContext.ReportProblems.Remove(reportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public ReportProblemResponse GetReportProblemById(GetReportProblemByIdQuery query)
        {
            var result = _dbContext.ReportProblems
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<ReportProblemResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<ReportProblemResponse> GetReportProblems(GetReportProblemsQuery query)
        {
            var result = _dbContext.ReportProblems
                .ProjectTo<ReportProblemResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateReportProblem(UpdateReportProblemCommand command, CancellationToken cancellationToken)
        {
            var reportProblem = _dbContext.ReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (reportProblem == null)
            {
                throw new Exception("The reported problem does not exists");
            }
            reportProblem.DateOfExpiry = command.DateOfExpiry;
            reportProblem.DateOfIssue = command.DateOfIssue;
            reportProblem.Description = command.Description;
            reportProblem.Title = command.Title;
            reportProblem.IsProcessed = true;

            _dbContext.ReportProblems.Update(reportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
