﻿using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Commands
{
    public class CreateMedicalCenterProcedureCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }
    }

    public class CreateMedicalCenterProcedureCommandHandler : IRequestHandler<CreateMedicalCenterProcedureCommand, RequestResponse>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public CreateMedicalCenterProcedureCommandHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public async Task<RequestResponse> Handle(CreateMedicalCenterProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterProcedureService.CreateMedicalCenterProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateMedicalCenterProcedureCommandValidator : AbstractValidator<CreateMedicalCenterProcedureCommand>
    {
        public CreateMedicalCenterProcedureCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.MedicalCenter).NotEmpty().NotNull();
            RuleFor(v => v.MedicalProcedure).NotEmpty().NotNull();
        }
    }
}
