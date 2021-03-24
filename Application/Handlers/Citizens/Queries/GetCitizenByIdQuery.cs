using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Handlers.Citizens.Queries
{
    public class GetCitizenByIdQuery : IRequest<CitizenResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCitizenByIdQueryHandler : IRequestHandler<GetCitizenByIdQuery, CitizenResponse>
    {
        private readonly ICitizenService _citizenService;

        public GetCitizenByIdQueryHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public Task<CitizenResponse> Handle(GetCitizenByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenService.GetCitizenById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
