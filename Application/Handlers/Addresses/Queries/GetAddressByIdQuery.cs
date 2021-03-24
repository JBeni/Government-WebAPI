using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressByIdQuery : IRequest<AddressByIdResponse>
    {
        public string County { get; set; }
    }

    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressByIdResponse>
    {
        private readonly IAddressService _addressService;

        public GetAddressByIdQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<AddressByIdResponse> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddressById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the address by Id", ex);
            }
        }
    }

    public class AddressByIdResponse : IMapFrom<Address>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Address, AddressByIdResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
