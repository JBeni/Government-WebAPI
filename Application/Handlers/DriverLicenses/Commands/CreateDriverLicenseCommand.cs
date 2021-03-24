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
        public int Id { get; set; }
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
            RuleFor(v => v.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
