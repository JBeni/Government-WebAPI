using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantGPs.Commands
{
    public class UpdatePublicServantGPCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class UpdatePublicServantGPsCommandHandler : IRequestHandler<UpdatePublicServantGPCommand, RequestResponse>
    {
        private readonly IPublicServantGPService _PublicServantGPService;

        public UpdatePublicServantGPsCommandHandler(IPublicServantGPService PublicServantGPService)
        {
            _PublicServantGPService = PublicServantGPService;
        }

        public async Task<RequestResponse> Handle(UpdatePublicServantGPCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _PublicServantGPService.UpdatePublicServantGP(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePublicServantGPCommandValidator : AbstractValidator<UpdatePublicServantGPCommand>
    {
        public UpdatePublicServantGPCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
