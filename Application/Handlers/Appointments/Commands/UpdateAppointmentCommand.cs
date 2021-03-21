using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Appointments.Commands
{
    public class UpdateAppointmentCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }

    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, RequestResponse>
    {
        private readonly IAppointmentService _appointmentService;

        public UpdateAppointmentCommandHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<RequestResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _appointmentService.UpdateMedicalAppointment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
