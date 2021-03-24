using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Commands
{
    public class UpdateMedicalPaymentHistoryCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public long AmountPaid { get; set; }
        public long AmountToPay { get; set; }
        public DateTime DateOfPayment { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public PublicServantGP PublicServantGP { get; set; }
        public Citizen CitizenWhoBenefit { get; set; }
        public Citizen CitizenWhoPaid { get; set; }
    }

    public class UpdateMedicalPaymentHistorysCommandHandler : IRequestHandler<UpdateMedicalPaymentHistoryCommand, RequestResponse>
    {
        private readonly IMedicalPaymentHistoryService _medicalPaymentHistoryService;

        public UpdateMedicalPaymentHistorysCommandHandler(IMedicalPaymentHistoryService medicalPaymentHistoryService)
        {
            _medicalPaymentHistoryService = medicalPaymentHistoryService;
        }

        public async Task<RequestResponse> Handle(UpdateMedicalPaymentHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalPaymentHistoryService.UpdateMedicalPaymentHistory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateMedicalPaymentHistoryCommandValidator : AbstractValidator<UpdateMedicalPaymentHistoryCommand>
    {
        public UpdateMedicalPaymentHistoryCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.AmountPaid).NotEmpty().NotNull();
            RuleFor(v => v.AmountToPay).NotEmpty().NotNull();
            RuleFor(v => v.DateOfPayment).NotEmpty().NotNull();
            RuleFor(v => v.MedicalProcedure).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenter).NotEmpty().NotNull();
            RuleFor(v => v.PublicServantGP).NotEmpty().NotNull();
            RuleFor(v => v.CitizenWhoBenefit).NotEmpty().NotNull();
            RuleFor(v => v.CitizenWhoPaid).NotEmpty().NotNull();
        }
    }
}
