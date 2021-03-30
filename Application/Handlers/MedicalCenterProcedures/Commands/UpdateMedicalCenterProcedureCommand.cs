using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Commands
{
    public class UpdateMedicalCenterProcedureCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public int MedicalCenterId { get; set; }
        public int MedicalProcedureId { get; set; }
    }

    public class UpdateMedicalCenterProcedureCommandHandler : IRequestHandler<UpdateMedicalCenterProcedureCommand, RequestResponse>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public UpdateMedicalCenterProcedureCommandHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public async Task<RequestResponse> Handle(UpdateMedicalCenterProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterProcedureService.UpdateMedicalCenterProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateMedicalCenterProcedureCommandValidator : AbstractValidator<UpdateMedicalCenterProcedureCommand>
    {
        public UpdateMedicalCenterProcedureCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalProcedureId).NotEmpty().NotNull();
        }
    }
}
