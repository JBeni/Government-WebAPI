using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantGPs.Commands
{
    public class CreatePublicServantGPCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class CreatePublicServantGPsCommandHandler : IRequestHandler<CreatePublicServantGPCommand, RequestResponse>
    {
        private readonly IPublicServantGPService _PublicServantGPService;

        public CreatePublicServantGPsCommandHandler(IPublicServantGPService PublicServantGPService)
        {
            _PublicServantGPService = PublicServantGPService;
        }

        public async Task<RequestResponse> Handle(CreatePublicServantGPCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _PublicServantGPService.CreatePublicServantGP(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePublicServantGPCommandValidator : AbstractValidator<CreatePublicServantGPCommand>
    {
        public CreatePublicServantGPCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
