using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.IdentityCards.Commands;
using GovernmentSystem.Application.Handlers.IdentityCards.Queries;
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
    public class IdentityCardService : IIdentityCardService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public IdentityCardService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateIdentityCard(CreateIdentityCardCommand command, CancellationToken cancellationToken)
        {
            var identityCard = _dbContext.IdentityCards.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (identityCard != null)
            {
                throw new Exception("The identity card already exists");
            }
            var entity = new IdentityCard
            {
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
                Series = command.Series,
                Type = command.Type
            };

            _dbContext.IdentityCards.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteIdentityCard(DeleteIdentityCardCommand command, CancellationToken cancellationToken)
        {
            var identityCard = _dbContext.IdentityCards.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (identityCard != null)
            {
                throw new Exception("The identity card does not exists");
            }

            _dbContext.IdentityCards.Remove(identityCard);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public IdentityCardResponse GetIdentityCardById(GetIdentityCardByIdQuery query)
        {
            var result = _dbContext.IdentityCards
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<IdentityCardResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<IdentityCardResponse> GetIdentityCards(GetIdentityCardsQuery query)
        {
            var result = _dbContext.IdentityCards
                .ProjectTo<IdentityCardResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateIdentityCard(UpdateIdentityCardCommand command, CancellationToken cancellationToken)
        {
            var identityCard = _dbContext.IdentityCards.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (identityCard != null)
            {
                throw new Exception("The identity card does not exists");
            }
            identityCard.Series = command.Series;
            identityCard.Type = command.Type;
            identityCard.DateOfIssue = command.DateOfIssue;
            identityCard.DateOfExpiry = command.DateOfExpiry;

            _dbContext.IdentityCards.Update(identityCard);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
