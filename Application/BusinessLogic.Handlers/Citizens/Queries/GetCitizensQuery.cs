using GovernmentSystem.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.BusinessLogic.Citizens.Handlers.Queries;

namespace GovernmentSystem.Application.BusinessLogic.Handlers.Citizens.Queries
{
    public class GetCitizensQuery : IRequest<List<CitizenDto>>
    {
    }

    public class GetCitizensQueryHandler : IRequestHandler<GetCitizensQuery, List<CitizenDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCitizensQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CitizenDto>> Handle(GetCitizensQuery request, CancellationToken cancellationToken)
        {
            return await _context.Citizens
                    .ProjectTo<CitizenDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.FirstName)
                    .ToListAsync(cancellationToken);
        }
    }
}
