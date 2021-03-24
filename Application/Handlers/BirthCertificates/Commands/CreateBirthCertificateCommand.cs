using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.BirthCertificates.Commands
{
    public class CreateBirthCertificateCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class CreateBirthCertificateCommandHandler : IRequestHandler<CreateBirthCertificateCommand, RequestResponse>
    {
        private readonly IBirthCertificateService _birthCertificateService;

        public CreateBirthCertificateCommandHandler(IBirthCertificateService birthCertificateService)
        {
            _birthCertificateService = birthCertificateService;
        }

        public async Task<RequestResponse> Handle(CreateBirthCertificateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _birthCertificateService.CreateBirthCertificate(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateBirthCertificateCommandValidator : AbstractValidator<CreateBirthCertificateCommand>
    {
        public CreateBirthCertificateCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
