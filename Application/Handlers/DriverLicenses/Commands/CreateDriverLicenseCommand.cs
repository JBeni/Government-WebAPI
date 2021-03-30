using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
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
        public int CategoryId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
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
            RuleFor(v => v.CategoryId).NotEmpty().NotNull();
            RuleFor(v => v.DateOfIssue).NotEmpty().NotNull();
            RuleFor(v => v.DateOfExpiry).NotEmpty().NotNull();
        }
    }
}
