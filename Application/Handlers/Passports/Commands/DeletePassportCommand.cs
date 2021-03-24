using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Passports.Commands
{
    public class DeletePassportCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class DeletePassportsCommandHandler : IRequestHandler<DeletePassportCommand, RequestResponse>
    {
        private readonly IPassportService _passportService;

        public DeletePassportsCommandHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public async Task<RequestResponse> Handle(DeletePassportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _passportService.DeletePassport(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePassportCommandValidator : AbstractValidator<DeletePassportCommand>
    {
        public DeletePassportCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
