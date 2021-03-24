using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPolices.Commands
{
    public class CreatePublicServantPoliceCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class CreatePublicServantPolicesCommandHandler : IRequestHandler<CreatePublicServantPoliceCommand, RequestResponse>
    {
        private readonly IPublicServantPoliceService _publicServantPoliceService;

        public CreatePublicServantPolicesCommandHandler(IPublicServantPoliceService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public async Task<RequestResponse> Handle(CreatePublicServantPoliceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantPoliceService.CreatePublicServantPolice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePublicServantPoliceCommandValidator : AbstractValidator<CreatePublicServantPoliceCommand>
    {
        public CreatePublicServantPoliceCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
