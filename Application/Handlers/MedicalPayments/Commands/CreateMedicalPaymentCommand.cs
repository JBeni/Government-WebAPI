using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalPayments.Commands
{
    public class CreateMedicalPaymentCommand : IRequest<RequestResponse>
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

    public class CreateMedicalPaymentCommandHandler : IRequestHandler<CreateMedicalPaymentCommand, RequestResponse>
    {
        private readonly IMedicalPaymentService _medicalPaymentyService;

        public CreateMedicalPaymentCommandHandler(IMedicalPaymentService medicalPaymentyService)
        {
            _medicalPaymentyService = medicalPaymentyService;
        }

        public async Task<RequestResponse> Handle(CreateMedicalPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalPaymentyService.CreateMedicalPayment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateMedicalPaymentCommandValidator : AbstractValidator<CreateMedicalPaymentCommand>
    {
        public CreateMedicalPaymentCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
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
