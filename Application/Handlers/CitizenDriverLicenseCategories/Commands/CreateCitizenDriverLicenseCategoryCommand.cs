﻿using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Commands
{
    public class CreateCitizenDriverLicenseCategoryCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public Guid CitizenId { get; set; }
        public Guid DriverLicenseCategoryId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }

    public class CreateCitizenDriverLicenseCategoryCommandHandler : IRequestHandler<CreateCitizenDriverLicenseCategoryCommand, RequestResponse>
    {
        private readonly ICitizenDriverLicenseCategoryService _service;

        public CreateCitizenDriverLicenseCategoryCommandHandler(ICitizenDriverLicenseCategoryService service)
        {
            _service = service;
        }

        public async Task<RequestResponse> Handle(CreateCitizenDriverLicenseCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.CreateCitizenDriverLicenseCategory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateCitizenDriverLicenseCategoryCommandValidator : AbstractValidator<CreateCitizenDriverLicenseCategoryCommand>
    {
        public CreateCitizenDriverLicenseCategoryCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.CitizenId).NotEmpty().NotNull();
            RuleFor(v => v.DriverLicenseCategoryId).NotEmpty().NotNull();
            RuleFor(v => v.DateOfIssue).NotEmpty().NotNull();
            RuleFor(v => v.DateOfExpiry).NotEmpty().NotNull();
        }
    }
}