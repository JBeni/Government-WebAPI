using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Domain.Entities.CitizenEntities;

namespace GovernmentSystem.Application.Handlers.Citizens.Queries
{
    public class CitizenRecord : IMapFrom<Citizen>
    {
        public string FirstName { get; set; }
        public bool Active { get; set; }
    }

    public class ExportCitizensVm
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }

    public class ExportCitizensQuery : IRequest<ExportCitizensVm>
    {
    }

    public class ExportCitizensQueryHandler : IRequestHandler<ExportCitizensQuery, ExportCitizensVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportCitizensQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportCitizensVm> Handle(ExportCitizensQuery request, CancellationToken cancellationToken)
        {
            var vm = new ExportCitizensVm();

            var records = await _context.Citizens
                    .ProjectTo<CitizenRecord>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            vm.Content = _fileBuilder.BuildCitizensFIle(records);
            vm.ContentType = "text/csv";
            vm.FileName = "TodoItems.csv";

            return await Task.FromResult(vm);
        }
    }
}
