﻿namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Commands
{
    public class CreateMedicalCenterProcedureCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public Guid MedicalCenterId { get; set; }
        public Guid MedicalProcedureId { get; set; }
    }

    public class CreateMedicalCenterProcedureCommandHandler : IRequestHandler<CreateMedicalCenterProcedureCommand, RequestResponse>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public CreateMedicalCenterProcedureCommandHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public async Task<RequestResponse> Handle(CreateMedicalCenterProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterProcedureService.CreateMedicalCenterProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreateMedicalCenterProcedureCommandValidator : AbstractValidator<CreateMedicalCenterProcedureCommand>
    {
        public CreateMedicalCenterProcedureCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalProcedureId).NotEmpty().NotNull();
        }
    }
}
