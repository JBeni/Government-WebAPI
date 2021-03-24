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

namespace GovernmentSystem.Infrastructure.Services
{
    public class CitizenRequestService : ICitizenRequestService
    {
        private readonly IApplicationDbContext _dbContext;

        public CitizenRequestService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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

            _dbContext.CitizenRequests.Add(citizenRequest);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return RequestResponse.Success();
        }

        public CitizenRequestResponse GetCitizenRequestById(GetCitizenRequestByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<CitizenRequestResponse> GetCitizenRequests(GetCitizenRequestsQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResponse> UpdateCitizenRequest(UpdateCitizenRequestCommand command, CancellationToken cancellationToken)
        {
            var citizenRequest = _dbContext.CitizenRequests.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenRequest == null)
            {
                throw new Exception("The citizen request does not exists");
            }

            citizenRequest.IsProcessed = true;

            _dbContext.CitizenRequests.Add(citizenRequest);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return RequestResponse.Success();
        }
    }
}