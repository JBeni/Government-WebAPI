using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Taxes.Queries
{
    public class GetTaxesQuery : IRequest<List<TaxResponse>>
    {
    }

    public class GetTaxesQueryHandler : IRequestHandler<GetTaxesQuery, List<TaxResponse>>
    {
        private readonly ITaxService _taxService;

        public GetTaxesQueryHandler(ITaxService taxService)
        {
            _taxService = taxService;
        }

        public Task<List<TaxResponse>> Handle(GetTaxesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _taxService.GetTaxes(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the taxes", ex);
            }
        }
    }
}
