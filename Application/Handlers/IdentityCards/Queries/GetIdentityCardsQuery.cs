using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.IdentityCards.Queries
{
    public class GetIdentityCardsQuery : IRequest<List<IdentityCardsResponse>>
    {
        public string County { get; set; }
    }

    public class GetIdentityCardsQueryHandler : IRequestHandler<GetIdentityCardsQuery, List<IdentityCardsResponse>>
    {
        private readonly IIdentityCardService _identityCardService;

        public GetIdentityCardsQueryHandler(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        public Task<List<IdentityCardsResponse>> Handle(GetIdentityCardsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _identityCardService.GetIdentityCards(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class IdentityCardsResponse : IMapFrom<IdentityCard>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<IdentityCard, IdentityCardsResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
