using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PolicePayments.Commands
{
    public class UpdatePolicePaymentCommand : IRequest<RequestResponse>
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

    public class UpdatePolicePaymentCommandHandler : IRequestHandler<UpdatePolicePaymentCommand, RequestResponse>
    {
        private readonly IPolicePaymentService _policePaymentService;

        public UpdatePolicePaymentCommandHandler(IPolicePaymentService policePaymentService)
        {
            _policePaymentService = policePaymentService;
        }

        public async Task<RequestResponse> Handle(UpdatePolicePaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _policePaymentService.UpdatePolicePayment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePolicePaymentCommandValidator : AbstractValidator<UpdatePolicePaymentCommand>
    {
        public UpdatePolicePaymentCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
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
