using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressesQuery : IRequest<List<AddressesResponse>>
    {
        public string County { get; set; }
    }

    public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, List<AddressesResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressesQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<List<AddressesResponse>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddresses(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
    }

    public class AddressesResponse : IMapFrom<Address>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Address, AddressesResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
