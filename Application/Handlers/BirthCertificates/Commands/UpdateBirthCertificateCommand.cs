using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.BirthCertificates.Commands
{
    public class UpdateBirthCertificateCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class UpdateBirthCertificateCommandHandler : IRequestHandler<UpdateBirthCertificateCommand, RequestResponse>
    {
        private readonly IBirthCertificateService _birthCertificateService;

        public UpdateBirthCertificateCommandHandler(IBirthCertificateService birthCertificateService)
        {
            _birthCertificateService = birthCertificateService;
        }

        public async Task<RequestResponse> Handle(UpdateBirthCertificateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _birthCertificateService.UpdateBirthCertificate(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateBirthCertificateCommandValidator : AbstractValidator<UpdateBirthCertificateCommand>
    {
        public UpdateBirthCertificateCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
