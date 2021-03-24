using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.IdentityCards.Queries
{
    public class GetIdentityCardByIdQuery : IRequest<IdentityCardResponse>
    {
        public string County { get; set; }
    }

    public class GetIdentityCardByIdQueryHandler : IRequestHandler<GetIdentityCardByIdQuery, IdentityCardResponse>
    {
        private readonly IIdentityCardService _identityCardService;

        public GetIdentityCardByIdQueryHandler(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        public Task<IdentityCardResponse> Handle(GetIdentityCardByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _identityCardService.GetIdentityCardById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class IdentityCardResponse : IMapFrom<IdentityCard>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<IdentityCard, IdentityCardResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
