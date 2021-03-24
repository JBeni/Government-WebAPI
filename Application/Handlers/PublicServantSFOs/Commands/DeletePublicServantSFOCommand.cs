using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantSFOs.Commands
{
    public class DeletePublicServantSFOCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePublicServantSFOHandler : IRequestHandler<DeletePublicServantSFOCommand, RequestResponse>
    {
        private readonly IPublicServantSFOService _publicServantSFOService;

        public DeletePublicServantSFOHandler(IPublicServantSFOService publicServantSFOService)
        {
            _publicServantSFOService = publicServantSFOService;
        }

        public async Task<RequestResponse> Handle(DeletePublicServantSFOCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantSFOService.DeletePublicServantSFO(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePublicServantSFOHandlerValidator : AbstractValidator<DeletePublicServantSFOCommand>
    {
        public DeletePublicServantSFOHandlerValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
