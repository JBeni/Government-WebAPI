using GovernmentSystem.Application.Handlers.CityReportProblems.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.CityReportProblems.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Domain.Entities.CityHalls;

namespace GovernmentSystem.Infrastructure.Services
{
    public class CityReportProblemService : ICityReportProblemService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public CityReportProblemService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateCityReportProblem(CreateCityReportProblemCommand command, CancellationToken cancellationToken)
        {
            var CityReportProblem = _dbContext.CityReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (CityReportProblem != null)
            {
                throw new Exception("The city hall reported problem already exists");
            }
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);
            var entity = new CityReportProblem
            {
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
                Description = command.Description,
                IsProcessed = false,
                Title = command.Title,
                CityHall = cityHall
            };

            _dbContext.CityReportProblems.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteCityReportProblem(DeleteCityReportProblemCommand command, CancellationToken cancellationToken)
        {
            var CityReportProblem = _dbContext.CityReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (CityReportProblem == null)
            {
                throw new Exception("The city hall reported problem does not exists");
            }

            _dbContext.CityReportProblems.Remove(CityReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public CityReportProblemResponse GetCityReportProblemById(GetCityReportProblemByIdQuery query)
        {
            var result = _dbContext.CityReportProblems
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<CityReportProblemResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<CityReportProblemResponse> GetCityReportProblems(GetCityReportProblemsQuery query)
        {
            var result = _dbContext.CityReportProblems
                .ProjectTo<CityReportProblemResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateCityReportProblem(UpdateCityReportProblemCommand command, CancellationToken cancellationToken)
        {
            var CityReportProblem = _dbContext.CityReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (CityReportProblem == null)
            {
                throw new Exception("The city hall reported problem does not exists");
            }
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);

            CityReportProblem.DateOfExpiry = command.DateOfExpiry;
            CityReportProblem.DateOfIssue = command.DateOfIssue;
            CityReportProblem.Description = command.Description;
            CityReportProblem.Title = command.Title;
            CityReportProblem.IsProcessed = command.IsProcessed;
            CityReportProblem.CityHall = cityHall;

            _dbContext.CityReportProblems.Update(CityReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
