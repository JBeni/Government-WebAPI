using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantSFOs.Commands
{
    public class UpdatePublicServantSFOCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
    }

    public class UpdatePublicServantSFOCommandHandler : IRequestHandler<UpdatePublicServantSFOCommand, RequestResponse>
    {
        private readonly IPublicServantSFOService _publicServantSFOService;

        public UpdatePublicServantSFOCommandHandler(IPublicServantSFOService publicServantSFOService)
        {
            _publicServantSFOService = publicServantSFOService;
        }

        public async Task<RequestResponse> Handle(UpdatePublicServantSFOCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantSFOService.UpdatePublicServantSFO(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePublicServantSFOCommandValidator : AbstractValidator<UpdatePublicServantSFOCommand>
    {
        public UpdatePublicServantSFOCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
