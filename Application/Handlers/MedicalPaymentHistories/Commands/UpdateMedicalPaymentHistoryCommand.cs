using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Commands
{
    public class UpdateMedicalPaymentHistoryCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
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
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
