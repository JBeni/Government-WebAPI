using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenters.Commands
{
    public class CreateMedicalCenterCommand : IRequest<RequestResponse>
    {
        public string Identifier { get; set; }
    }

    public class CreateMedicalCentersCommandHandler : IRequestHandler<CreateMedicalCenterCommand, RequestResponse>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public CreateMedicalCentersCommandHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public async Task<RequestResponse> Handle(CreateMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterService.AddMedicalCenter(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateMedicalCenterCommandValidator : AbstractValidator<CreateMedicalCenterCommand>
    {
        public CreateMedicalCenterCommandValidator()
        {
            RuleFor(v => v.Identifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
