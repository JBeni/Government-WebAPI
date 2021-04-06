using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PolicePayments.Commands
{
    public class CreatePolicePaymentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public long AmountPaid { get; set; }
        public long AmountToPay { get; set; }
        public DateTime DateOfPayment { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid PoliceStationId { get; set; }
        public Guid CitizenId { get; set; }
    }

    public class CreatePolicePaymentCommandHandler : IRequestHandler<CreatePolicePaymentCommand, RequestResponse>
    {
        private readonly IPolicePaymentService _policePaymentService;

        public CreatePolicePaymentCommandHandler(IPolicePaymentService policePaymentService)
        {
            _policePaymentService = policePaymentService;
        }

        public async Task<RequestResponse> Handle(CreatePolicePaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _policePaymentService.CreatePolicePayment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePolicePaymentCommandValidator : AbstractValidator<CreatePolicePaymentCommand>
    {
        public CreatePolicePaymentCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.AmountPaid).NotEmpty().NotNull();
            RuleFor(v => v.AmountToPay).NotEmpty().NotNull();
            RuleFor(v => v.DateOfPayment).NotEmpty().NotNull();
            RuleFor(v => v.InvoiceId).NotEmpty().NotNull();
            RuleFor(v => v.PoliceStationId).NotEmpty().NotNull();
            RuleFor(v => v.CitizenId).NotEmpty().NotNull();
        }
    }
}
