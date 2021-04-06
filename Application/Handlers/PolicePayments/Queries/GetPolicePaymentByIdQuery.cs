using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PolicePayments.Queries
{
    public class GetPolicePaymentByIdQuery : IRequest<PolicePaymentResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPolicePaymentByIdQueryHandler : IRequestHandler<GetPolicePaymentByIdQuery, PolicePaymentResponse>
    {
        private readonly IPolicePaymentService _policePaymentService;

        public GetPolicePaymentByIdQueryHandler(IPolicePaymentService policePaymentService)
        {
            _policePaymentService = policePaymentService;
        }

        public Task<PolicePaymentResponse> Handle(GetPolicePaymentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policePaymentService.GetPolicePaymentById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the police payment by Id", ex);
            }
        }
    }
}
