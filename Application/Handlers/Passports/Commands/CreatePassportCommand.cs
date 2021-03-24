﻿using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Passports.Commands
{
    public class CreatePassportCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class CreatePassportsCommandHandler : IRequestHandler<CreatePassportCommand, RequestResponse>
    {
        private readonly IPassportService _passportService;

        public CreatePassportsCommandHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public async Task<RequestResponse> Handle(CreatePassportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _passportService.CreatePassport(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePassportCommandValidator : AbstractValidator<CreatePassportCommand>
    {
        public CreatePassportCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}