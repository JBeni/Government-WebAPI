using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPolices.Commands
{
    public class CreatePublicServantPoliceCommand : IRequest<RequestResponse>
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

    public class CreatePublicServantPolicesCommandHandler : IRequestHandler<CreatePublicServantPoliceCommand, RequestResponse>
    {
        private readonly IPublicServantPoliceService _publicServantPoliceService;

        public CreatePublicServantPolicesCommandHandler(IPublicServantPoliceService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public async Task<RequestResponse> Handle(CreatePublicServantPoliceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantPoliceService.CreatePublicServantPolice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePublicServantPoliceCommandValidator : AbstractValidator<CreatePublicServantPoliceCommand>
    {
        public CreatePublicServantPoliceCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
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
