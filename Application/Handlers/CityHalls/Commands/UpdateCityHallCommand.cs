using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Domain.Entities.CityHallEntity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityHalls.Commands
{
    public class UpdateCityHallCommand : IRequest<RequestResponse>
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class UpdateCityHallCommandHandler : IRequestHandler<UpdateCityHallCommand, RequestResponse>
    {
        private readonly ICityHallService _cityHallService;

        public UpdateCityHallCommandHandler(ICityHallService cityHallService)
        {
            _cityHallService = cityHallService;
        }

        public async Task<RequestResponse> Handle(UpdateCityHallCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityHallService.UpdateCityHall(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateCityHallCommandValidator : AbstractValidator<UpdateCityHallCommand>
    {
        public UpdateCityHallCommandValidator()
        {
            RuleFor(v => v.Identifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
