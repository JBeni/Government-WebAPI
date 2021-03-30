using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;

namespace GovernmentSystem.Application.Handlers.Citizens.Commands
{
    public class CreateCitizenCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int DateOfBirthId { get; set; }
        public int PlaceOfBirthId { get; set; }
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
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.Age).NotEmpty().NotNull();
            RuleFor(v => v.Gender).NotEmpty().NotNull();
            RuleFor(v => v.DateOfBirthId).NotEmpty().NotNull();
            RuleFor(v => v.PlaceOfBirthId).NotEmpty().NotNull();
        }
    }
}
