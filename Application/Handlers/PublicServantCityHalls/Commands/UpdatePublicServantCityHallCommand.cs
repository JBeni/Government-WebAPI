using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantCityHalls.Commands
{
    public class UpdatePublicServantCityHallCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public CityHall CityHall { get; set; }
    }

    public class UpdatePublicServantCityHallsCommandHandler : IRequestHandler<UpdatePublicServantCityHallCommand, RequestResponse>
    {
        private readonly IPublicServantCityHallService _publicServantCityHallService;

        public UpdatePublicServantCityHallsCommandHandler(IPublicServantCityHallService publicServantCityHallService)
        {
            _publicServantCityHallService = publicServantCityHallService;
        }

        public async Task<RequestResponse> Handle(UpdatePublicServantCityHallCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantCityHallService.UpdatePublicServantCityHall(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePublicServantCityHallCommandValidator : AbstractValidator<UpdatePublicServantCityHallCommand>
    {
        public UpdatePublicServantCityHallCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.CNP).NotEmpty().NotNull();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.DutyRole).NotEmpty().NotNull();
            RuleFor(v => v.ContractYears).NotEmpty().NotNull();
            RuleFor(v => v.HireStartDate).NotEmpty().NotNull();
            RuleFor(v => v.HireEndDate).NotEmpty().NotNull();
            RuleFor(v => v.CityHall).NotEmpty().NotNull();
        }
    }
}
