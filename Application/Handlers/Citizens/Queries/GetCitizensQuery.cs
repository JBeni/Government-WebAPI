using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Interfaces;
using System;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Handlers.Citizens.Queries
{
    public class GetCitizensQuery : IRequest<List<CitizenResponse>>
    {
    }

    public class GetCitizensQueryHandler : IRequestHandler<GetCitizensQuery, List<CitizenResponse>>
    {
        private readonly ICitizenService _citizenService;

        public GetCitizensQueryHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public Task<List<CitizenResponse>> Handle(GetCitizensQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenService.GetCitizens(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the citizens", ex);
            }
        }
    }
}
