using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantSFOs.Commands
{
    public class CreatePublicServantSFOCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public Guid SFOId { get; set; }
    }

    public class CreatePublicServantSFOCommandHandler : IRequestHandler<CreatePublicServantSFOCommand, RequestResponse>
    {
        private readonly IPublicServantSFOService _publicServantSFOService;

        public CreatePublicServantSFOCommandHandler(IPublicServantSFOService publicServantSFOService)
        {
            _publicServantSFOService = publicServantSFOService;
        }

        public async Task<RequestResponse> Handle(CreatePublicServantSFOCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantSFOService.CreatePublicServantSFO(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePublicServantSFOCommandValidator : AbstractValidator<CreatePublicServantSFOCommand>
    {
        public CreatePublicServantSFOCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.CNP).NotEmpty().NotNull();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.DutyRole).NotEmpty().NotNull();
            RuleFor(v => v.ContractYears).NotEmpty().NotNull();
            RuleFor(v => v.HireStartDate).NotEmpty().NotNull();
            RuleFor(v => v.HireEndDate).NotEmpty().NotNull();
            RuleFor(v => v.SFOId).NotEmpty().NotNull();
        }
    }
}
