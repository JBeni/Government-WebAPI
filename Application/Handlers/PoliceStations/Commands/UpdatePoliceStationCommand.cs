﻿using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PoliceStations.Commands
{
    public class UpdatePoliceStationCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string StationName { get; set; }
        public Guid AddressId { get; set; }
        public Guid CityHallId { get; set; }
    }

    public class UpdatePoliceStationsCommandHandler : IRequestHandler<UpdatePoliceStationCommand, RequestResponse>
    {
        private readonly IPoliceStationService _policeStationService;

        public UpdatePoliceStationsCommandHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public async Task<RequestResponse> Handle(UpdatePoliceStationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _policeStationService.UpdatePoliceStation(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePoliceStationCommandValidator : AbstractValidator<UpdatePoliceStationCommand>
    {
        public UpdatePoliceStationCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.StationName).NotEmpty().NotNull();
            RuleFor(v => v.AddressId).NotEmpty().NotNull();
            RuleFor(v => v.CityHallId).NotEmpty().NotNull();
        }
    }
}
