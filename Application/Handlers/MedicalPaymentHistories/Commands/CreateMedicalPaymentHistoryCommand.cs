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
        public string UniqueIdentifier { get; set; }
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
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
