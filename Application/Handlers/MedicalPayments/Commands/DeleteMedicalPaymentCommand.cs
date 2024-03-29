﻿namespace GovernmentSystem.Application.Handlers.MedicalPayments.Commands
{
    public class DeleteMedicalPaymentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteMedicalPaymentCommandHandler : IRequestHandler<DeleteMedicalPaymentCommand, RequestResponse>
    {
        private readonly IMedicalPaymentService _medicalPaymentyService;

        public DeleteMedicalPaymentCommandHandler(IMedicalPaymentService medicalPaymentyService)
        {
            _medicalPaymentyService = medicalPaymentyService;
        }

        public async Task<RequestResponse> Handle(DeleteMedicalPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalPaymentyService.DeleteMedicalPayment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteMedicalPaymentCommandValidator : AbstractValidator<DeleteMedicalPaymentCommand>
    {
        public DeleteMedicalPaymentCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
