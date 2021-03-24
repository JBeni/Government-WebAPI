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
    public class GetAddressByTypeQuery : IRequest<List<AddressByTypeResponse>>
    {
        public string County { get; set; }
    }

    public class GetAddressByTypeQueryHandler : IRequestHandler<GetAddressByTypeQuery, List<AddressByTypeResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressByTypeQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<List<AddressByTypeResponse>> Handle(GetAddressByTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddressByType(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
    }

    public class AddressByTypeResponse : IMapFrom<Address>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Address, AddressByTypeResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
