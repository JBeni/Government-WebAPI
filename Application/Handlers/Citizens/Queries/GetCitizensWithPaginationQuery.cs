using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Domain.Entities.CitizenEntities;

namespace GovernmentSystem.Application.Handlers.Citizens.Queries
{
    public class CitizenDto : IMapFrom<Citizen>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Citizen, CitizenDto>()
            //    .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName));
        }
    }

    public class GetCitizensWithPaginationQuery : IRequest<PaginatedList<CitizenDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetCitizensWithPaginationQueryHandler : IRequestHandler<GetCitizensWithPaginationQuery, PaginatedList<CitizenDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCitizensWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CitizenDto>> Handle(GetCitizensWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Citizens
                .OrderBy(x => x.FirstName)
                .ProjectTo<CitizenDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }

    public class GetCitizensWithPaginationQueryValidator : AbstractValidator<GetCitizensWithPaginationQuery>
    {
        public GetCitizensWithPaginationQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }

    }
}
