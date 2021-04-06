using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Companies.Commands
{
    public class UpdateCompanyCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CIF { get; set; }
        public string Name { get; set; }
        public DateTime FoundationYear { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DeletionDate { get; set; }
        public Guid FounderId { get; set; }
        public Guid OfficeAddressId { get; set; }
    }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, RequestResponse>
    {
        private readonly ICompanyService _companyService;

        public UpdateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<RequestResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _companyService.UpdateCompany(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.CIF).NotEmpty().NotNull();
            RuleFor(v => v.Name).NotEmpty().NotNull();
            RuleFor(v => v.FoundationYear).NotEmpty().NotNull();
            RuleFor(v => v.Domain).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.Status).NotEmpty().NotNull();
            RuleFor(v => v.DeletionDate).NotEmpty().NotNull();
            RuleFor(v => v.FounderId).NotEmpty().NotNull();
            RuleFor(v => v.OfficeAddressId).NotEmpty().NotNull();
        }
    }
}
