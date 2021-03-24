using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPolices.Commands
{
    public class DeletePublicServantPoliceCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePublicServantPolicesCommandHandler : IRequestHandler<DeletePublicServantPoliceCommand, RequestResponse>
    {
        private readonly IPublicServantPoliceService _publicServantPoliceService;

        public DeletePublicServantPolicesCommandHandler(IPublicServantPoliceService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public async Task<RequestResponse> Handle(DeletePublicServantPoliceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantPoliceService.DeletePublicServantPolice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePublicServantPoliceCommandValidator : AbstractValidator<DeletePublicServantPoliceCommand>
    {
        public DeletePublicServantPoliceCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
