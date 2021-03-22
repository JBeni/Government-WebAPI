using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityHalls.Commands
{
    public class DeleteCityHallCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class DeleteCityHallCommandHandler : IRequestHandler<DeleteCityHallCommand, RequestResponse>
    {
        private readonly ICityHallService _cityHallService;

        public DeleteCityHallCommandHandler(ICityHallService cityHallService)
        {
            _cityHallService = cityHallService;
        }

        public async Task<RequestResponse> Handle(DeleteCityHallCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _cityHallService.DeleteCityHall(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteCityHallCommandValidator : AbstractValidator<DeleteCityHallCommand>
    {
        public DeleteCityHallCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
