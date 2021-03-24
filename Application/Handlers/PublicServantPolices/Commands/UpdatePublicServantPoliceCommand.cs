using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPolices.Commands
{
    public class UpdatePublicServantPoliceCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class UpdatePublicServantPolicesCommandHandler : IRequestHandler<UpdatePublicServantPoliceCommand, RequestResponse>
    {
        private readonly IPublicServantPoliceService _publicServantPoliceService;

        public UpdatePublicServantPolicesCommandHandler(IPublicServantPoliceService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public async Task<RequestResponse> Handle(UpdatePublicServantPoliceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantPoliceService.UpdatePublicServantPolice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePublicServantPoliceCommandValidator : AbstractValidator<UpdatePublicServantPoliceCommand>
    {
        public UpdatePublicServantPoliceCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
