using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Interfaces;
using System;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CitizenEntities;

namespace GovernmentSystem.Application.Handlers.Citizens.Queries
{
    public class ExportCitizensQuery : IRequest<ExportCitizensVm>
    {
    }

    public class ExportCitizensQueryHandler : IRequestHandler<ExportCitizensQuery, ExportCitizensVm>
    {
        private readonly ICitizenService _citizenService;

        public ExportCitizensQueryHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public Task<ExportCitizensVm> Handle(ExportCitizensQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenService.ExportCitizensQuery(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

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
}
