using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
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
        public int CitizenId { get; set; }
        public int PublicServantGPId { get; set; }
        public int MedicalCenterId { get; set; }
        public int MedicalAppointmentId { get; set; }
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
            RuleFor(v => v.CitizenId).NotEmpty().NotNull();
            RuleFor(v => v.PublicServantGPId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalAppointmentId).NotEmpty().NotNull();
        }
    }
}
