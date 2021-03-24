using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Commands
{
    public class UpdateCitizenMedicalHistoryCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Symptoms { get; set; }
        public string HealthProblem { get; set; }
        public DateTime DateOfDiagnostic { get; set; }
        public string Treatment { get; set; }
        public string AdditionalInformation { get; set; }
        public Citizen Citizen { get; set; }
        public PublicServantGP PublicServantGP { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public MedicalAppointment MedicalAppointment { get; set; }
    }

    public class UpdateCitizenMedicalHistoryCommandHandler : IRequestHandler<UpdateCitizenMedicalHistoryCommand, RequestResponse>
    {
        private readonly ICitizenMedicalHistoryService _citizenMedicalHistoryService;

        public UpdateCitizenMedicalHistoryCommandHandler(ICitizenMedicalHistoryService citizenMedicalHistoryService)
        {
            _citizenMedicalHistoryService = citizenMedicalHistoryService;
        }

        public async Task<RequestResponse> Handle(UpdateCitizenMedicalHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenMedicalHistoryService.UpdateCitizenMedicalHistory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateCitizenMedicalHistoryCommandValidator : AbstractValidator<UpdateCitizenMedicalHistoryCommand>
    {
        public UpdateCitizenMedicalHistoryCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Symptoms).NotEmpty().NotNull();
            RuleFor(v => v.HealthProblem).NotEmpty().NotNull();
            RuleFor(v => v.DateOfDiagnostic).NotEmpty().NotNull();
            RuleFor(v => v.Treatment).NotEmpty().NotNull();
            RuleFor(v => v.AdditionalInformation).NotEmpty().NotNull();
            RuleFor(v => v.Citizen).NotEmpty().NotNull();
            RuleFor(v => v.PublicServantGP).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenter).NotEmpty().NotNull();
            RuleFor(v => v.MedicalAppointment).NotEmpty().NotNull();
        }
    }
}
