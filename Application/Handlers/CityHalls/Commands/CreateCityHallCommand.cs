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
        public Guid Identifier { get; set; }
        public string CityHallName { get; set; }
        public DateTime ConstructionDate { get; set; }
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
                return await _cityHallService.CreateCityHall(request, cancellationToken);
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
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.CityHallName).NotEmpty().NotNull();
            RuleFor(v => v.ConstructionDate).NotEmpty().NotNull();
            RuleFor(v => v.Address).NotEmpty().NotNull();
        }
    }
}
