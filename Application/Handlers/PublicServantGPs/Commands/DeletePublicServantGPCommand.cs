using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantGPs.Commands
{
    public class DeletePublicServantGPCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class DeletePublicServantGPsCommandHandler : IRequestHandler<DeletePublicServantGPCommand, RequestResponse>
    {
        private readonly IPublicServantGPService _PublicServantGPService;

        public DeletePublicServantGPsCommandHandler(IPublicServantGPService PublicServantGPService)
        {
            _PublicServantGPService = PublicServantGPService;
        }

        public async Task<RequestResponse> Handle(DeletePublicServantGPCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _PublicServantGPService.DeletePublicServantGP(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePublicServantGPCommandValidator : AbstractValidator<DeletePublicServantGPCommand>
    {
        public DeletePublicServantGPCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
