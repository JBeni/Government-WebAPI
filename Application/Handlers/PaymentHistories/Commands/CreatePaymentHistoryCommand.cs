using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PaymentHistories.Commands
{
    public class CreatePaymentHistoryCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstitutionType { get; set; }
        public long AmountToPay { get; set; }
        public long AmountPaid { get; set; }
        public DateTime DateOfPayment { get; set; }
        public Guid CitizenWhoPaidId { get; set; }
    }

    public class CreatePaymentHistoryCommandHandler : IRequestHandler<CreatePaymentHistoryCommand, RequestResponse>
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        public CreatePaymentHistoryCommandHandler(IPaymentHistoryService paymentHistoryService)
        {
            _paymentHistoryService = paymentHistoryService;
        }

        public async Task<RequestResponse> Handle(CreatePaymentHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _paymentHistoryService.CreatePaymentHistory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePaymentHistoryCommandValidator : AbstractValidator<CreatePaymentHistoryCommand>
    {
        public CreatePaymentHistoryCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.InstitutionType).NotEmpty().NotNull();
            RuleFor(v => v.AmountToPay).NotEmpty().NotNull();
            RuleFor(v => v.AmountPaid).NotEmpty().NotNull();
            RuleFor(v => v.DateOfPayment).NotEmpty().NotNull();
            RuleFor(v => v.CitizenWhoPaidId).NotEmpty().NotNull();
        }
    }
}
