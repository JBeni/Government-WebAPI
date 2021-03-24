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
    public class CreateCitizenMedicalHistoryCommand : IRequest<RequestResponse>
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

    public class CreateCitizenMedicalHistoryCommandHandler : IRequestHandler<CreateCitizenMedicalHistoryCommand, RequestResponse>
    {
        private readonly ICitizenMedicalHistoryService _citizenMedicalHistoryService;

        public CreateCitizenMedicalHistoryCommandHandler(ICitizenMedicalHistoryService citizenMedicalHistoryService)
        {
            _citizenMedicalHistoryService = citizenMedicalHistoryService;
        }

        public async Task<RequestResponse> Handle(CreateCitizenMedicalHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenMedicalHistoryService.CreateCitizenMedicalHistory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateCitizenMedicalHistoryCommandValidator : AbstractValidator<CreateCitizenMedicalHistoryCommand>
    {
        public CreateCitizenMedicalHistoryCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
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
