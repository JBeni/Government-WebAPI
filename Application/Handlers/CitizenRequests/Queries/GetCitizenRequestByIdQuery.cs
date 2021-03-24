using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CitizenRequests.Queries
{
    public class GetCitizenRequestByIdQuery : IRequest<CitizenRequestResponse>
    {
        public int Id { get; set; }
    }

    public class GetCitizenRequestByIdQueryHandler : IRequestHandler<GetCitizenRequestByIdQuery, CitizenRequestResponse>
    {
        private readonly ICitizenRequestService _citizenRequestService;

        public GetCitizenRequestByIdQueryHandler(ICitizenRequestService citizenRequestService)
        {
            _citizenRequestService = citizenRequestService;
        }

        public Task<CitizenRequestResponse> Handle(GetCitizenRequestByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenRequestService.GetCitizenRequestById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the medical history of citizen", ex);
            }
        }
    }
}
