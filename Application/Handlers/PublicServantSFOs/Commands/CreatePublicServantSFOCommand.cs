using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantSFOs.Commands
{
    public class CreatePublicServantSFOCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class CreatePublicServantSFOCommandHandler : IRequestHandler<CreatePublicServantSFOCommand, RequestResponse>
    {
        private readonly IPublicServantSFOService _publicServantSFOService;

        public CreatePublicServantSFOCommandHandler(IPublicServantSFOService publicServantSFOService)
        {
            _publicServantSFOService = publicServantSFOService;
        }

        public async Task<RequestResponse> Handle(CreatePublicServantSFOCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantSFOService.CreatePublicServantSFO(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePublicServantSFOCommandValidator : AbstractValidator<CreatePublicServantSFOCommand>
    {
        public CreatePublicServantSFOCommandValidator()
        {
            RuleFor(v => v.Identifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
