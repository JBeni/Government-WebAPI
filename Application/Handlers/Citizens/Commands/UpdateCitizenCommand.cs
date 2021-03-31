using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using System;

namespace GovernmentSystem.Application.Handlers.Citizens.Commands
{
    public class UpdateCitizenCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid IdentityCardId { get; set; }
        public Guid PassportId { get; set; }
        public Guid DriverLicenseId { get; set; }
        public Guid CityHallResidenceId { get; set; }
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
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.IdentityCardId).NotEmpty().NotNull();
            RuleFor(v => v.PassportId).NotEmpty().NotNull();
            RuleFor(v => v.DriverLicenseId).NotEmpty().NotNull();
            RuleFor(v => v.CityHallResidenceId).NotEmpty().NotNull();
        }
    }
}
