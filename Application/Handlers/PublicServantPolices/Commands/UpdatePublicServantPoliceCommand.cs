using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPolices.Commands
{
    public class UpdatePublicServantPoliceCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public int PoliceStationId { get; set; }
    }

    public class UpdatePublicServantPolicesCommandHandler : IRequestHandler<UpdatePublicServantPoliceCommand, RequestResponse>
    {
        private readonly IPublicServantPoliceService _publicServantPoliceService;

        public UpdatePublicServantPolicesCommandHandler(IPublicServantPoliceService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public async Task<RequestResponse> Handle(UpdatePublicServantPoliceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantPoliceService.UpdatePublicServantPolice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePublicServantPoliceCommandValidator : AbstractValidator<UpdatePublicServantPoliceCommand>
    {
        public UpdatePublicServantPoliceCommandValidator()
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
