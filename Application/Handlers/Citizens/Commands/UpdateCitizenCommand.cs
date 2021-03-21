﻿using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using System;
using GovernmentSystem.Domain.Entities.Citizen;
using GovernmentSystem.Domain.Entities.CityHallEntity;

namespace GovernmentSystem.Application.Handlers.Citizens.Commands
{
    public class UpdateCitizenCommand : IRequest<RequestResponse>
    {
        public string CNP { get; set; }
        public IdentityCard IdentityCard { get; set; }
        public Passport Passport { get; set; }
        public DriverLicense DriverLicense { get; set; }
        public CityHall CityHallResidence { get; set; }
    }

    public class UpdateCitizenCommandHandler : IRequestHandler<UpdateCitizenCommand, RequestResponse>
    {
        private readonly ICitizenService _citizenService;

        public UpdateCitizenCommandHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public async Task<RequestResponse> Handle(UpdateCitizenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenService.UpdateCitizen(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateCitizenCommandValidator : AbstractValidator<UpdateCitizenCommand>
    {
        public UpdateCitizenCommandValidator()
        {
            RuleFor(v => v.CNP)
                .NotEmpty()
                .NotNull();
        }
    }
}