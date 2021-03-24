using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.IdentityCards.Commands
{
    public class DeleteIdentityCardCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteIdentityCardCommandHandler : IRequestHandler<DeleteIdentityCardCommand, RequestResponse>
    {
        private readonly IIdentityCardService _identityCardService;

        public DeleteIdentityCardCommandHandler(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        public async Task<RequestResponse> Handle(DeleteIdentityCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _identityCardService.DeleteIdentityCard(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteIdentityCardCommandValidator : AbstractValidator<DeleteIdentityCardCommand>
    {
        public DeleteIdentityCardCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
