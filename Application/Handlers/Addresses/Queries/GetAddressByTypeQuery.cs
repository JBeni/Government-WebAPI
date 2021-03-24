using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressByTypeQuery : IRequest<List<AddressResponse>>
    {
        public string County { get; set; }
    }

    public class GetAddressByTypeQueryHandler : IRequestHandler<GetAddressByTypeQuery, List<AddressResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressByTypeQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<List<AddressResponse>> Handle(GetAddressByTypeQuery request, CancellationToken cancellationToken)
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
}
