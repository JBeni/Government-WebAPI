using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.IdentityCardAppointments.Commands
{
    public class CreateIdentityCardAppointmentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Reason { get; set; }
        public DateTime AppointmentDay { get; set; }
        public string AdditionalInformation { get; set; }
        public Guid CitizenId { get; set; }
    }

    public class CreateIdentityCardAppointmentCommandHandler : IRequestHandler<CreateIdentityCardAppointmentCommand, RequestResponse>
    {
        private readonly IIdentityCardAppointmentService _identityCardAppointmentService;

        public CreateIdentityCardAppointmentCommandHandler(IIdentityCardAppointmentService identityCardAppointmentService)
        {
            _identityCardAppointmentService = identityCardAppointmentService;
        }

        public async Task<RequestResponse> Handle(CreateIdentityCardAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _identityCardAppointmentService.CreateIdentityCardAppointment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateIdentityCardAppointmentCommandValidator : AbstractValidator<CreateIdentityCardAppointmentCommand>
    {
        public CreateIdentityCardAppointmentCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Reason).NotEmpty().NotNull();
            RuleFor(v => v.AppointmentDay).NotEmpty().NotNull();
            RuleFor(v => v.AdditionalInformation).NotEmpty().NotNull();
            RuleFor(v => v.CitizenId).NotEmpty().NotNull();
        }
    }
}
