using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantGPs.Commands
{
    public class UpdatePublicServantGPCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public int MedicalCenterId { get; set; }
    }

    public class UpdatePublicServantGPsCommandHandler : IRequestHandler<UpdatePublicServantGPCommand, RequestResponse>
    {
        private readonly IPublicServantGPService _PublicServantGPService;

        public UpdatePublicServantGPsCommandHandler(IPublicServantGPService PublicServantGPService)
        {
            _PublicServantGPService = PublicServantGPService;
        }

        public async Task<RequestResponse> Handle(UpdatePublicServantGPCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _PublicServantGPService.UpdatePublicServantGP(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePublicServantGPCommandValidator : AbstractValidator<UpdatePublicServantGPCommand>
    {
        public UpdatePublicServantGPCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
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
