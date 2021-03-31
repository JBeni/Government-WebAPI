using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Handlers.AddressTypes.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Linq;

namespace GovernmentSystem.Infrastructure.Services
{
    public class AddressTypeService : IAddressTypeService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddressTypeService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AddressTypeResponse GetAddressTypeById(GetAddressTypeByIdQuery query)
        {
            var result = _dbContext.AddressTypes
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<AddressTypeResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<AddressTypeResponse> GetAddressTypes(GetAddressTypesQuery query)
        {
            var result = _dbContext.AddressTypes
                .ProjectTo<AddressTypeResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }
    }
}
