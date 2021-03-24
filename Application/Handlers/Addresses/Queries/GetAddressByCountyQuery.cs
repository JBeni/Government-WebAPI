using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressByCountyQuery : IRequest<List<AddressResponse>>
    {
        public string County { get; set; }
    }

    public class GetAddressByCountyQueryHandler : IRequestHandler<GetAddressByCountyQuery, List<AddressResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressByCountyQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<List<AddressResponse>> Handle(GetAddressByCountyQuery request, CancellationToken cancellationToken)
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
}
