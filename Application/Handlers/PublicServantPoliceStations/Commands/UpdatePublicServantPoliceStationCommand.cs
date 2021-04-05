using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Commands
{
    public class UpdatePublicServantPoliceStationCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public Guid PoliceStationId { get; set; }
    }

    public class UpdatePublicServantPoliceStationCommandHandler : IRequestHandler<UpdatePublicServantPoliceStationCommand, RequestResponse>
    {
        private readonly IPublicServantPoliceStationService _publicServantPoliceService;

        public UpdatePublicServantPoliceStationCommandHandler(IPublicServantPoliceStationService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public async Task<RequestResponse> Handle(UpdatePublicServantPoliceStationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantPoliceService.UpdatePublicServantPoliceStation(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePublicServantPoliceStationCommandValidator : AbstractValidator<UpdatePublicServantPoliceStationCommand>
    {
        public UpdatePublicServantPoliceStationCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.CNP).NotEmpty().NotNull();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.DutyRole).NotEmpty().NotNull();
            RuleFor(v => v.ContractYears).NotEmpty().NotNull();
            RuleFor(v => v.HireStartDate).NotEmpty().NotNull();
            RuleFor(v => v.HireEndDate).NotEmpty().NotNull();
            RuleFor(v => v.PoliceStationId).NotEmpty().NotNull();
        }
    }
}
