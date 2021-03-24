using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Passports.Commands
{
    public class UpdatePassportCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class UpdatePassportsCommandHandler : IRequestHandler<UpdatePassportCommand, RequestResponse>
    {
        private readonly IPassportService _passportService;

        public UpdatePassportsCommandHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public async Task<RequestResponse> Handle(UpdatePassportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _passportService.UpdatePassport(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePassportCommandValidator : AbstractValidator<UpdatePassportCommand>
    {
        public UpdatePassportCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
