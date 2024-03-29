﻿namespace GovernmentSystem.Infrastructure.Services
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
            return RequestResponse.Success(entity.Identifier);
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
            return RequestResponse.Success(citizenRequest.Identifier);
        }

        public Result<CitizenRequestResponse> GetCitizenRequestById(GetCitizenRequestByIdQuery query)
        {
            var result = _dbContext.CitizenRequests
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<CitizenRequestResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<CitizenRequestResponse> { Successful = true, Item = result ?? new CitizenRequestResponse() };
        }

        public Result<CitizenRequestResponse> GetCitizenRequests(GetCitizenRequestsQuery query)
        {
            var result = _dbContext.CitizenRequests
                .ProjectTo<CitizenRequestResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<CitizenRequestResponse> { Successful = true, Items = result ?? new List<CitizenRequestResponse>() };
        }

        public async Task<RequestResponse> UpdateCitizenRequest(UpdateCitizenRequestCommand command, CancellationToken cancellationToken)
        {
            var citizenRequest = _dbContext.CitizenRequests.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenRequest == null)
            {
                throw new Exception("The citizen request does not exists");
            }
            citizenRequest.DateOfExpiry = command.DateOfExpiry;
            citizenRequest.DateOfIssue = command.DateOfIssue;
            citizenRequest.Description = command.Description;
            citizenRequest.IsProcessed = command.IsProcessed;
            citizenRequest.Type = command.Type;
            citizenRequest.UserCNP = command.UserCNP;
            citizenRequest.UserName = command.UserName;

            _dbContext.CitizenRequests.Update(citizenRequest);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(citizenRequest.Identifier);
        }
    }
}