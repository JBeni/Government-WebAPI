using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Commands
{
    public class UpdateCitizenMedicalHistoryCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Treatment { get; set; }
        public string AdditionalInformation { get; set; }
        public int CitizenId { get; set; }
        public int PublicServantGPId { get; set; }
        public int MedicalCenterId { get; set; }
        public int MedicalAppointmentId { get; set; }
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
            RuleFor(v => v.Treatment).NotEmpty().NotNull();
            RuleFor(v => v.AdditionalInformation).NotEmpty().NotNull();
            RuleFor(v => v.CitizenId).NotEmpty().NotNull();
            RuleFor(v => v.PublicServantGPId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalAppointmentId).NotEmpty().NotNull();
        }
    }
}
