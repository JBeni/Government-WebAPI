using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Commands
{
    public class DeleteMedicalPaymentHistoryCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class DeleteMedicalPaymentHistorysCommandHandler : IRequestHandler<DeleteMedicalPaymentHistoryCommand, RequestResponse>
    {
        private readonly IMedicalPaymentHistoryService _medicalPaymentHistoryService;

        public DeleteMedicalPaymentHistorysCommandHandler(IMedicalPaymentHistoryService medicalPaymentHistoryService)
        {
            _medicalPaymentHistoryService = medicalPaymentHistoryService;
        }

        public async Task<RequestResponse> Handle(DeleteMedicalPaymentHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalPaymentHistoryService.DeleteMedicalPaymentHistory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteMedicalPaymentHistoryCommandValidator : AbstractValidator<DeleteMedicalPaymentHistoryCommand>
    {
        public DeleteMedicalPaymentHistoryCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
