using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.IdentityCardAppointments.Queries
{
    public class GetIdentityCardAppointmentByIdQuery : IRequest<IdentityCardAppointmentResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetIdentityCardAppointmentByIdQueryHandler : IRequestHandler<GetIdentityCardAppointmentByIdQuery, IdentityCardAppointmentResponse>
    {
        private readonly IIdentityCardAppointmentService _identityCardAppointmentService;

        public GetIdentityCardAppointmentByIdQueryHandler(IIdentityCardAppointmentService identityCardAppointmentService)
        {
            _identityCardAppointmentService = identityCardAppointmentService;
        }

        public Task<IdentityCardAppointmentResponse> Handle(GetIdentityCardAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _identityCardAppointmentService.GetIdentityCardAppointmentById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the identity card appointment by Id", ex);
            }
        }
    }
}
