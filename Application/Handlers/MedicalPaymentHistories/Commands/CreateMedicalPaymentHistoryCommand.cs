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
    public class CreateMedicalPaymentHistoryCommand : IRequest<RequestResponse>
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
            RuleFor(v => v.MedicalProcedure).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenter).NotEmpty().NotNull();
            RuleFor(v => v.PublicServantGP).NotEmpty().NotNull();
            RuleFor(v => v.CitizenWhoBenefit).NotEmpty().NotNull();
            RuleFor(v => v.CitizenWhoPaid).NotEmpty().NotNull();
        }
    }
}
