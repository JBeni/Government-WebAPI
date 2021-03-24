using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using GovernmentSystem.Domain.Entities.CitizenEntities;

namespace GovernmentSystem.Application.Handlers.Citizens.Commands
{
    public class CreateCitizenCommand : IRequest<RequestResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public BirthCertificate DateOfBirth { get; set; }
        public Address PlaceOfBirth { get; set; }
    }

    public class CreateCitizenCommandHandler : IRequestHandler<CreateCitizenCommand, RequestResponse>
    {
        private readonly ICitizenService _citizenService;

        public CreateCitizenCommandHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public async Task<RequestResponse> Handle(CreateCitizenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _citizenService.CreateCitizen(request, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateCitizenCommandValidator : AbstractValidator<CreateCitizenCommand>
    {
        public CreateCitizenCommandValidator()
        {
            RuleFor(v => v.DateOfBirth)
                .NotEmpty()
                .NotNull();
        }
    }
}
