using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantCityHalls.Commands
{
    public class DeletePublicServantCityHallCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class DeletePublicServantCityHallsCommandHandler : IRequestHandler<DeletePublicServantCityHallCommand, RequestResponse>
    {
        private readonly IPublicServantCityHallService _publicServantCityHallService;

        public DeletePublicServantCityHallsCommandHandler(IPublicServantCityHallService publicServantCityHallService)
        {
            _publicServantCityHallService = publicServantCityHallService;
        }

        public async Task<RequestResponse> Handle(DeletePublicServantCityHallCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantCityHallService.DeletePublicServantCityHall(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePublicServantCityHallCommandValidator : AbstractValidator<DeletePublicServantCityHallCommand>
    {
        public DeletePublicServantCityHallCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
