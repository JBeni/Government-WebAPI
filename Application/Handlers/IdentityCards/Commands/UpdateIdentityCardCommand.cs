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
        public Guid Identifier { get; set; }
        public string Series { get; set; }
        public string Type { get; set; }
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
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Series).NotEmpty().NotNull();
            RuleFor(v => v.Type).NotEmpty().NotNull();
        }
    }
}
