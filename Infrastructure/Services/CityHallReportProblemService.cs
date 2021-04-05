using GovernmentSystem.Application.Handlers.CityHallReportProblems.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.CityHallReportProblems.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Domain.Entities.CityHallEntities;

namespace GovernmentSystem.Infrastructure.Services
{
    public class CityHallReportProblemService : ICityHallReportProblemService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CityHallReportProblemService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateCityHallReportProblem(CreateCityHallReportProblemCommand command, CancellationToken cancellationToken)
        {
            var cityHallReportProblem = _dbContext.CityHallReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHallReportProblem != null)
            {
                throw new Exception("The city hall reported problem already exists");
            }
            var entity = new CityHallReportProblem
            {
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
                Description = command.Description,
                IsProcessed = false,
                Title = command.Title
            };

            _dbContext.CityHallReportProblems.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteCityHallReportProblem(DeleteCityHallReportProblemCommand command, CancellationToken cancellationToken)
        {
            var cityHallReportProblem = _dbContext.CityHallReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHallReportProblem == null)
            {
                throw new Exception("The city hall reported problem does not exists");
            }

            _dbContext.CityHallReportProblems.Remove(cityHallReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public CityHallReportProblemResponse GetCityHallReportProblemById(GetCityHallReportProblemByIdQuery query)
        {
            var result = _dbContext.CityHallReportProblems
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<CityHallReportProblemResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<CityHallReportProblemResponse> GetCityHallReportProblems(GetCityHallReportProblemsQuery query)
        {
            var result = _dbContext.CityHallReportProblems
                .ProjectTo<CityHallReportProblemResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateCityHallReportProblem(UpdateCityHallReportProblemCommand command, CancellationToken cancellationToken)
        {
            var cityHallReportProblem = _dbContext.CityHallReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHallReportProblem == null)
            {
                throw new Exception("The city hall reported problem does not exists");
            }
            cityHallReportProblem.DateOfExpiry = command.DateOfExpiry;
            cityHallReportProblem.DateOfIssue = command.DateOfIssue;
            cityHallReportProblem.Description = command.Description;
            cityHallReportProblem.Title = command.Title;
            cityHallReportProblem.IsProcessed = true;

            _dbContext.CityHallReportProblems.Update(cityHallReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
