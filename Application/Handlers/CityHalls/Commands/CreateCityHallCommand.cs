using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityHalls.Commands
{
    public class CreateCityHallCommand : IRequest<RequestResponse>
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class CreateCityHallCommandHandler : IRequestHandler<CreateCityHallCommand, RequestResponse>
    {
        private readonly ICityHallService _cityHallService;

        public CreateCityHallCommandHandler(ICityHallService cityHallService)
        {
            _cityHallService = cityHallService;
        }

        public async Task<RequestResponse> Handle(CreateCityHallCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityHallService.AddCityHall(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateCityHallCommandValidator : AbstractValidator<CreateCityHallCommand>
    {
        public CreateCityHallCommandValidator()
        {
            RuleFor(v => v.Identifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
