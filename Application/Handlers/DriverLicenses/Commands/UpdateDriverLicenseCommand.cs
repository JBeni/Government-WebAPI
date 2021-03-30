using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.DriverLicenses.Commands
{
    public class UpdateDriverLicenseCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string LicenseNumber { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateDriverLicenseCommandHandler : IRequestHandler<UpdateDriverLicenseCommand, RequestResponse>
    {
        private readonly IDriverLicenseService _driverLicenseService;

        public UpdateDriverLicenseCommandHandler(IDriverLicenseService driverLicenseService)
        {
            _driverLicenseService = driverLicenseService;
        }

        public async Task<RequestResponse> Handle(UpdateDriverLicenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _driverLicenseService.UpdateDriverLicense(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateDriverLicenseCommandValidator : AbstractValidator<UpdateDriverLicenseCommand>
    {
        public UpdateDriverLicenseCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.LicenseNumber).NotEmpty().NotNull();
            RuleFor(v => v.CategoryId).NotEmpty().NotNull();

        }
    }
}
