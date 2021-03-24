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
    public class GetAddressByCountyQuery : IRequest<List<AddressByCountyResponse>>
    {
        public string County { get; set; }
    }

    public class GetAddressByCountyQueryHandler : IRequestHandler<GetAddressByCountyQuery, List<AddressByCountyResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressByCountyQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<List<AddressByCountyResponse>> Handle(GetAddressByCountyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddressByCounty(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the address by county", ex);
            }
        }
    }

    public class AddressByCountyResponse : IMapFrom<Address>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Address, AddressByCountyResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
