using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.AddressTypes.Queries
{
    public class GetAddressTypeByIdQuery : IRequest<AddressTypeResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetAddressTypeByIdQueryHandler : IRequestHandler<GetAddressTypeByIdQuery, AddressTypeResponse>
    {
        private readonly IAddressTypeService _addressTypeService;

        public GetAddressTypeByIdQueryHandler(IAddressTypeService addressTypeService)
        {
            _addressTypeService = addressTypeService;
        }

        public Task<AddressTypeResponse> Handle(GetAddressTypeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressTypeService.GetAddressTypeById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the address type by Id", ex);
            }
        }
    }
}
