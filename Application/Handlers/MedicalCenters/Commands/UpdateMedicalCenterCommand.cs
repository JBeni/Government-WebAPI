using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenters.Commands
{
    public class UpdateMedicalCenterCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class UpdateMedicalCenterCommandHandler : IRequestHandler<UpdateMedicalCenterCommand, RequestResponse>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public UpdateMedicalCenterCommandHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public async Task<RequestResponse> Handle(UpdateMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterService.UpdateMedicalCenter(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateMedicalCenterCommandValidator : AbstractValidator<UpdateMedicalCenterCommand>
    {
        public UpdateMedicalCenterCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
