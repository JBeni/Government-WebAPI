using GovernmentSystem.Application.Handlers.CitizenRequests.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Application.Handlers.CitizenRequests.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace GovernmentSystem.Infrastructure.Services
{
    public class CitizenRequestService : ICitizenRequestService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CitizenRequestService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateCitizenRequest(CreateCitizenRequestCommand command, CancellationToken cancellationToken)
        {
            var citizenRequest = _dbContext.CitizenRequests.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenRequest != null)
            {
                throw new Exception("The citizen request already exists");
            }

            var entity = new CitizenRequest
            {
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
                Description = command.Description,
                IsProcessed = false,
                Type = command.Type,
                UserCNP = command.UserCNP,
                UserName = command.UserName
            };

            _dbContext.CitizenRequests.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteCitizenRequest(DeleteCitizenRequestCommand command, CancellationToken cancellationToken)
        {
            var citizenRequest = _dbContext.CitizenRequests.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenRequest == null)
            {
                throw new Exception("The citizen request does not exists");
            }

            _dbContext.CitizenRequests.Remove(citizenRequest);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public CitizenRequestResponse GetCitizenRequestById(GetCitizenRequestByIdQuery query)
        {
            var result = _dbContext.CitizenRequests
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<CitizenRequestResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<CitizenRequestResponse> GetCitizenRequests(GetCitizenRequestsQuery query)
        {
            var result = _dbContext.CitizenRequests
                .ProjectTo<CitizenRequestResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateCitizenRequest(UpdateCitizenRequestCommand command, CancellationToken cancellationToken)
        {
            var citizenRequest = _dbContext.CitizenRequests.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenRequest == null)
            {
                throw new Exception("The citizen request does not exists");
            }
            citizenRequest.IsProcessed = true;
            citizenRequest.DateOfExpiry = command.DateOfExpiry;

            _dbContext.CitizenRequests.Update(citizenRequest);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}