using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantSeriousFraudOffices.Queries
{
    public class GetPublicServantSeriousFraudOfficesQuery : IRequest<List<PublicServantSeriousFraudOfficeResponse>>
    {
    }

    public class GetPublicServantSeriousFraudOfficesQueryHandler : IRequestHandler<GetPublicServantSeriousFraudOfficesQuery, List<PublicServantSeriousFraudOfficeResponse>>
    {
        private readonly IPublicServantSeriousFraudOfficeservice _publicServantSeriousFraudOfficesService;

        public GetPublicServantSeriousFraudOfficesQueryHandler(IPublicServantSeriousFraudOfficeservice publicServantSeriousFraudOfficeService)
        {
            _publicServantSeriousFraudOfficesService = publicServantSeriousFraudOfficeService;
        }

        public Task<List<PublicServantSeriousFraudOfficeResponse>> Handle(GetPublicServantSeriousFraudOfficesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantSeriousFraudOfficesService.GetPublicServantSeriousFraudOffices(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
