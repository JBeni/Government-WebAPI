using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Appointments.Commands
{
    public class DeleteAppointmentCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, RequestResponse>
    {
        private readonly IAppointmentService _appointmentService;

        public DeleteAppointmentCommandHandler(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<RequestResponse> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _appointmentService.DeleteMedicalAppointment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteAppointmentCommandValidator : AbstractValidator<DeleteAppointmentCommand>
    {
        public DeleteAppointmentCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
