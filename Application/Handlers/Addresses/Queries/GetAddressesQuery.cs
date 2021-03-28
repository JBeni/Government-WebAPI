using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressesQuery : IRequest<List<AddressResponse>>
    {
    }

    public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, List<AddressResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressesQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<List<AddressResponse>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddresses(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the addresses", ex);
            }
        }
    }
}
