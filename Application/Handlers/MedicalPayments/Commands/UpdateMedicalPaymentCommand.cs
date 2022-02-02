namespace GovernmentSystem.Application.Handlers.MedicalPayments.Commands
{
    public class UpdateMedicalPaymentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public long AmountPaid { get; set; }
        public long AmountToPay { get; set; }
        public DateTime DateOfPayment { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid MedicalProcedureId { get; set; }
        public Guid MedicalCenterId { get; set; }
        public Guid PublicServantMedicalCenterId { get; set; }
        public Guid CitizenWhoBenefitId { get; set; }
        public Guid CitizenWhoPaidId { get; set; }
    }

    public class UpdateMedicalPaymentCommandHandler : IRequestHandler<UpdateMedicalPaymentCommand, RequestResponse>
    {
        private readonly IMedicalPaymentService _medicalPaymentyService;

        public UpdateMedicalPaymentCommandHandler(IMedicalPaymentService medicalPaymentyService)
        {
            _medicalPaymentyService = medicalPaymentyService;
        }

        public async Task<RequestResponse> Handle(UpdateMedicalPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalPaymentyService.UpdateMedicalPayment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdateMedicalPaymentCommandValidator : AbstractValidator<UpdateMedicalPaymentCommand>
    {
        public UpdateMedicalPaymentCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.AmountPaid).NotEmpty().NotNull();
            RuleFor(v => v.AmountToPay).NotEmpty().NotNull();
            RuleFor(v => v.DateOfPayment).NotEmpty().NotNull();
            RuleFor(v => v.InvoiceId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalProcedureId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
            RuleFor(v => v.PublicServantMedicalCenterId).NotEmpty().NotNull();
            RuleFor(v => v.CitizenWhoBenefitId).NotEmpty().NotNull();
            RuleFor(v => v.CitizenWhoPaidId).NotEmpty().NotNull();
        }
    }
}
