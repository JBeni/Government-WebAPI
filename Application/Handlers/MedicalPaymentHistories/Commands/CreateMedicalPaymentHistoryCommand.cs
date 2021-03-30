using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Commands
{
    public class CreateMedicalPaymentHistoryCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public long AmountPaid { get; set; }
        public long AmountToPay { get; set; }
        public DateTime DateOfPayment { get; set; }
        public int MedicalProcedureId { get; set; }
        public int MedicalCenterId { get; set; }
        public int PublicServantGPId { get; set; }
        public int CitizenWhoBenefitId { get; set; }
        public int CitizenWhoPaidId { get; set; }
    }

    public class CreateMedicalPaymentHistorysCommandHandler : IRequestHandler<CreateMedicalPaymentHistoryCommand, RequestResponse>
    {
        private readonly IMedicalPaymentHistoryService _medicalPaymentHistoryService;

        public CreateMedicalPaymentHistorysCommandHandler(IMedicalPaymentHistoryService medicalPaymentHistoryService)
        {
            _medicalPaymentHistoryService = medicalPaymentHistoryService;
        }

        public async Task<RequestResponse> Handle(CreateMedicalPaymentHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalPaymentHistoryService.CreateMedicalPaymentHistory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateMedicalPaymentHistoryCommandValidator : AbstractValidator<CreateMedicalPaymentHistoryCommand>
    {
        public CreateMedicalPaymentHistoryCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.AmountPaid).NotEmpty().NotNull();
            RuleFor(v => v.AmountToPay).NotEmpty().NotNull();
            RuleFor(v => v.DateOfPayment).NotEmpty().NotNull();
            RuleFor(v => v.MedicalProcedureId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
            RuleFor(v => v.PublicServantGPId).NotEmpty().NotNull();
            RuleFor(v => v.CitizenWhoBenefitId).NotEmpty().NotNull();
            RuleFor(v => v.CitizenWhoPaidId).NotEmpty().NotNull();
        }
    }
}
