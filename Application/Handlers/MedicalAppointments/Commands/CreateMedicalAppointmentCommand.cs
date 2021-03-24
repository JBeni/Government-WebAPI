using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using GovernmentSystem.Domain.Entities.CitizenEntities;

namespace GovernmentSystem.Application.Handlers.Appointments.Commands
{
    public class CreateMedicalAppointmentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Symptoms { get; set; }
        public DateTime AppointmentDay { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }
        public Citizen Citizen { get; set; }
        public PublicServantGP PublicServantGP { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }

    public class CreateMedicalAppointmentCommandHandler : IRequestHandler<CreateMedicalAppointmentCommand, RequestResponse>
    {
        private readonly IMedicalAppointmentService _appointmentService;

        public CreateMedicalAppointmentCommandHandler(IMedicalAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<RequestResponse> Handle(CreateMedicalAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _appointmentService.CreateMedicalAppointment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateMedicalAppointmentCommandValidator : AbstractValidator<CreateMedicalAppointmentCommand>
    {
        public CreateMedicalAppointmentCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Symptoms).NotEmpty().NotNull();
            RuleFor(v => v.AppointmentDay).NotEmpty().NotNull();
            RuleFor(v => v.MedicalProcedure).NotEmpty().NotNull();
            RuleFor(v => v.Citizen).NotEmpty().NotNull();
            RuleFor(v => v.PublicServantGP).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenter).NotEmpty().NotNull();
        }
    }
}
