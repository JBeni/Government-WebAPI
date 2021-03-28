using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CitizenRequests.Queries
{
    public class GetCitizenRequestsQuery : IRequest<List<CitizenRequestResponse>>
    {
    }

    public class GetCitizenRequestsQueryHandler : IRequestHandler<GetCitizenRequestsQuery, List<CitizenRequestResponse>>
    {
        private readonly ICitizenRequestService _citizenRequestService;

        public GetCitizenRequestsQueryHandler(ICitizenRequestService citizenRequestService)
        {
            _citizenRequestService = citizenRequestService;
        }

        public Task<List<CitizenRequestResponse>> Handle(GetCitizenRequestsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenRequestService.GetCitizenRequests(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the citizen requests", ex);
            }
        }
    }
}
