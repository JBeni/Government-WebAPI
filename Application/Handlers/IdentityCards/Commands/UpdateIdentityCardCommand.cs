using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.IdentityCards.Commands
{
    public class UpdateIdentityCardCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }

    public class UpdateIdentityCardCommandHandler : IRequestHandler<UpdateIdentityCardCommand, RequestResponse>
    {
        private readonly IIdentityCardService _identityCardService;

        public UpdateIdentityCardCommandHandler(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        public async Task<RequestResponse> Handle(UpdateIdentityCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _identityCardService.UpdateIdentityCard(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateIdentityCardCommandValidator : AbstractValidator<UpdateIdentityCardCommand>
    {
        public UpdateIdentityCardCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
