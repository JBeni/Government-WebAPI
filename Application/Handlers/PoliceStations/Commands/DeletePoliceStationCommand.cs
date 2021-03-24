using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PoliceStations.Commands
{
    public class DeletePoliceStationCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class DeletePoliceStationsCommandHandler : IRequestHandler<DeletePoliceStationCommand, RequestResponse>
    {
        private readonly IPoliceStationService _policeStationService;

        public DeletePoliceStationsCommandHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public async Task<RequestResponse> Handle(DeletePoliceStationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _policeStationService.DeletePoliceStation(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePoliceStationCommandValidator : AbstractValidator<DeletePoliceStationCommand>
    {
        public DeletePoliceStationCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
