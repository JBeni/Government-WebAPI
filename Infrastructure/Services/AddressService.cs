using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.Addresses.Commands;
using GovernmentSystem.Application.Handlers.Addresses.Queries;
using GovernmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        private readonly IApplicationDbContext _dbContext;

        public AddressService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<RequestResponse> CreateAddress(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeleteAddress(DeleteAddressCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public List<AddressByCountyResponse> GetAddressByCounty(GetAddressByCountyQuery query)
        {
            throw new NotImplementedException();
        }

        public AddressByIdResponse GetAddressById(GetAddressByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<AddressByTypeResponse> GetAddressByType(GetAddressByTypeQuery query)
        {
            throw new NotImplementedException();
        }

        public List<AddressesResponse> GetAddresses(GetAddressesQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdateAddress(UpdateAddressCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
