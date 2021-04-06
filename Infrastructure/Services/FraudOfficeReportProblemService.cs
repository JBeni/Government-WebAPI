using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Commands;
using GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using GovernmentSystem.Domain.Entities.SeriousFraudOffices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class FraudOfficeReportProblemService : IFraudOfficeReportProblemService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public FraudOfficeReportProblemService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateFraudOfficeReportProblem(CreateFraudOfficeReportProblemCommand command, CancellationToken cancellationToken)
        {
            var fraudOfficeReportProblem = _dbContext.FraudOfficeReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (fraudOfficeReportProblem != null)
            {
                throw new Exception("The fraud office report problem already exists");
            }
            var seriousFraudOffice = _insideEntityService.GetSeriousFraudOfficeById(command.SeriousFraudOfficeId);
            var entity = new FraudOfficeReportProblem
            {
                Title = command.Title,
                Description = command.Description,
                IsProcessed = false,
                SeriousFraudOffice = seriousFraudOffice
            };

            _dbContext.FraudOfficeReportProblems.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteFraudOfficeReportProblem(DeleteFraudOfficeReportProblemCommand command, CancellationToken cancellationToken)
        {
            var fraudOfficeReportProblem = _dbContext.FraudOfficeReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (fraudOfficeReportProblem != null)
            {
                throw new Exception("The fraud office report problem does not exists");
            }

            _dbContext.FraudOfficeReportProblems.Remove(fraudOfficeReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public FraudOfficeReportProblemResponse GetFraudOfficeReportProblemById(GetFraudOfficeReportProblemByIdQuery query)
        {
            var result = _dbContext.FraudOfficeReportProblems
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<FraudOfficeReportProblemResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<FraudOfficeReportProblemResponse> GetFraudOfficeReportProblems(GetFraudOfficeReportProblemsQuery query)
        {
            var result = _dbContext.FraudOfficeReportProblems
                .ProjectTo<FraudOfficeReportProblemResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateFraudOfficeReportProblem(UpdateFraudOfficeReportProblemCommand command, CancellationToken cancellationToken)
        {
            var fraudOfficeReportProblem = _dbContext.FraudOfficeReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (fraudOfficeReportProblem != null)
            {
                throw new Exception("The fraud office report problem does not exists");
            }
            var seriousFraudOffice = _insideEntityService.GetSeriousFraudOfficeById(command.SeriousFraudOfficeId);

            fraudOfficeReportProblem.Title = command.Title;
            fraudOfficeReportProblem.Description = command.Description;
            fraudOfficeReportProblem.IsProcessed = true;
            fraudOfficeReportProblem.SeriousFraudOffice = seriousFraudOffice;

            _dbContext.FraudOfficeReportProblems.Update(fraudOfficeReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
