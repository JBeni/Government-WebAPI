using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.Passports.Commands;
using GovernmentSystem.Application.Handlers.Passports.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PassportService : IPassportService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PassportService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreatePassport(CreatePassportCommand command, CancellationToken cancellationToken)
        {
            var passport = _dbContext.Passports.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (passport != null)
            {
                throw new Exception("The passport already exists");
            }
            var entity = new Passport
            {
                Country = command.Country,
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
                PassportNumber = command.PassportNumber,
                Type = command.Type
            };

            _dbContext.Passports.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeletePassport(DeletePassportCommand command, CancellationToken cancellationToken)
        {
            var passport = _dbContext.Passports.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (passport != null)
            {
                throw new Exception("The passport does not exists");
            }

            _dbContext.Passports.Remove(passport);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public PassportResponse GetPassportById(GetPassportByIdQuery query)
        {
            var result = _dbContext.Passports
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PassportResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<PassportResponse> GetPassports(GetPassportsQuery query)
        {
            var result = _dbContext.Passports
                .ProjectTo<PassportResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdatePassport(UpdatePassportCommand command, CancellationToken cancellationToken)
        {
            var passport = _dbContext.Passports.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (passport != null)
            {
                throw new Exception("The passport does not exists");
            }

            _dbContext.Passports.Update(passport);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
