using GovernmentSystem.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Citizens.Queries
{
    public class GetCitizenByIdQuery : IRequest<CitizenDto>
    {
        public int Id { get; set; }
    }

    public class GetCitizenByIdQueryHandler : IRequestHandler<GetCitizenByIdQuery, CitizenDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCitizenByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CitizenDto> Handle(GetCitizenByIdQuery request, CancellationToken cancellationToken)
        {
            return _context.Citizens
                    .ProjectTo<CitizenDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(t => t.Id == request.Id);
        }
    }
}
