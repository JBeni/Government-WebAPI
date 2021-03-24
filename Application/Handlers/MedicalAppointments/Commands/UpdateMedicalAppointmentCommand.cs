﻿using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Appointments.Commands
{
    public class UpdateMedicalAppointmentCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }

    public class UpdateMedicalAppointmentCommandHandler : IRequestHandler<UpdateMedicalAppointmentCommand, RequestResponse>
    {
        private readonly IMedicalAppointmentService _appointmentService;

        public UpdateMedicalAppointmentCommandHandler(IMedicalAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<RequestResponse> Handle(UpdateMedicalAppointmentCommand request, CancellationToken cancellationToken)
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

    public class UpdateMedicalAppointmentCommandValidator : AbstractValidator<UpdateMedicalAppointmentCommand>
    {
        public UpdateMedicalAppointmentCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}