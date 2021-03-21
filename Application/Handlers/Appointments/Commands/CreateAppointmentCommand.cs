using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Appointments.Commands
{
    public class CreateAppointmentCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }

    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, RequestResponse>
    {
        private readonly IAppointmentService _appointmentService;

        public CreateAppointmentCommandHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<RequestResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _appointmentService.AddMedicalAppointment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
