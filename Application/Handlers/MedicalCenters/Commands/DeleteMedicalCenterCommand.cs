using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenters.Commands
{
    public class DeleteMedicalCenterCommand : IRequest<RequestResponse>
    {
        public string Identifier { get; set; }
    }

    public class DeleteMedicalCenterCommandHandler : IRequestHandler<DeleteMedicalCenterCommand, RequestResponse>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public DeleteMedicalCenterCommandHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public async Task<RequestResponse> Handle(DeleteMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalCenterService.DeleteMedicalCenter(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteMedicalCenterCommandValidator : AbstractValidator<DeleteMedicalCenterCommand>
    {
        public DeleteMedicalCenterCommandValidator()
        {
            RuleFor(v => v.Identifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
