﻿using GovernmentSystem.Application.Handlers.ReportProblems.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Domain.Entities.CitizenEntities;

namespace GovernmentSystem.Infrastructure.Services
{
    public class ReportProblemService : IReportProblemService
    {
        private readonly IApplicationDbContext _dbContext;

        public ReportProblemService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
 
        public async Task<RequestResponse> AddReportProblem(CreateReportProblemCommand command, CancellationToken cancellationToken)
        {
            var reportProblem = _dbContext.ReportProblems.SingleOrDefault(x => x.Id == command.Id);
            if (reportProblem != null)
            {
                throw new Exception("The reported problem already exists");
            }

            var entity = new ReportProblem
            {
            };

            _dbContext.ReportProblems.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteReportProblem(DeleteReportProblemCommand command, CancellationToken cancellationToken)
        {
            var reportProblem = _dbContext.ReportProblems.SingleOrDefault(x => x.Id == command.Id);
            if (reportProblem == null)
            {
                throw new Exception("The reported problem does not exists");
            }

            _dbContext.ReportProblems.Add(reportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateReportProblem(UpdateReportProblemCommand command, CancellationToken cancellationToken)
        {
            var reportProblem = _dbContext.ReportProblems.SingleOrDefault(x => x.Id == command.Id);
            if (reportProblem == null)
            {
                throw new Exception("The reported problem does not exists");
            }

            reportProblem.IsProcessed = true;

            _dbContext.ReportProblems.Add(reportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
