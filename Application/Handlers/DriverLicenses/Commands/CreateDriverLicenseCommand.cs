using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.DriverLicenses.Commands
{
    public class CreateDriverLicenseCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string LicenseNumber { get; set; }
        public DriverLicenseCategory Category { get; set; }
    }

    public class CreateDriverLicenseCommandHandler : IRequestHandler<CreateDriverLicenseCommand, RequestResponse>
    {
        private readonly IDriverLicenseService _driverLicenseService;

        public CreateDriverLicenseCommandHandler(IDriverLicenseService driverLicenseService)
        {
            _driverLicenseService = driverLicenseService;
        }

        public async Task<RequestResponse> Handle(CreateDriverLicenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _driverLicenseService.CreateDriverLicense(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateDriverLicenseCommandValidator : AbstractValidator<CreateDriverLicenseCommand>
    {
        public CreateDriverLicenseCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.LicenseNumber).NotEmpty().NotNull();
            RuleFor(v => v.Category).NotEmpty().NotNull();
        }
    }
}
