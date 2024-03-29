﻿namespace GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Commands
{
    public class UpdatePublicServantMedicalCenterCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public Guid MedicalCenterId { get; set; }
    }

    public class UpdatePublicServantMedicalCentersCommandHandler : IRequestHandler<UpdatePublicServantMedicalCenterCommand, RequestResponse>
    {
        private readonly IPublicServantMedicalCenterService _publicServantMedicalCenterService;

        public UpdatePublicServantMedicalCentersCommandHandler(IPublicServantMedicalCenterService publicServantMedicalCenterService)
        {
            _publicServantMedicalCenterService = publicServantMedicalCenterService;
        }

        public async Task<RequestResponse> Handle(UpdatePublicServantMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantMedicalCenterService.UpdatePublicServantMedicalCenter(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdatePublicServantMedicalCenterCommandValidator : AbstractValidator<UpdatePublicServantMedicalCenterCommand>
    {
        public UpdatePublicServantMedicalCenterCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.CNP).NotEmpty().NotNull();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.DutyRole).NotEmpty().NotNull();
            RuleFor(v => v.ContractYears).NotEmpty().NotNull();
            RuleFor(v => v.HireStartDate).NotEmpty().NotNull();
            RuleFor(v => v.HireEndDate).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
        }
    }
}
