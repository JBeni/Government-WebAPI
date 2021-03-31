using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantGPs.Commands
{
    public class CreatePublicServantGPCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public Guid MedicalCenterId { get; set; }
    }

    public class CreatePublicServantGPsCommandHandler : IRequestHandler<CreatePublicServantGPCommand, RequestResponse>
    {
        private readonly IPublicServantGPService _PublicServantGPService;

        public CreatePublicServantGPsCommandHandler(IPublicServantGPService PublicServantGPService)
        {
            _PublicServantGPService = PublicServantGPService;
        }

        public async Task<RequestResponse> Handle(CreatePublicServantGPCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _PublicServantGPService.CreatePublicServantGP(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePublicServantGPCommandValidator : AbstractValidator<CreatePublicServantGPCommand>
    {
        public CreatePublicServantGPCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.CNP).NotEmpty().NotNull();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.DutyRole).NotEmpty().NotNull();
            RuleFor(v => v.ContractYears).NotEmpty().NotNull();
            RuleFor(v => v.HireStartDate).NotEmpty().NotNull();
            RuleFor(v => v.HireEndDate).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
        }
    }
}
