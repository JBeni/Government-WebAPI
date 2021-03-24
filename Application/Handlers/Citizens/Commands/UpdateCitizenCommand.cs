using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using System;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Domain.Entities.CityHallEntities;

namespace GovernmentSystem.Application.Handlers.Citizens.Commands
{
    public class UpdateCitizenCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
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
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.IdentityCard).NotEmpty().NotNull();
            RuleFor(v => v.Passport).NotEmpty().NotNull();
            RuleFor(v => v.DriverLicense).NotEmpty().NotNull();
            RuleFor(v => v.CityHallResidence).NotEmpty().NotNull();
        }
    }
}
