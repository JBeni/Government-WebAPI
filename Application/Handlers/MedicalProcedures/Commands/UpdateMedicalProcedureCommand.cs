using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Commands
{
    public class UpdateMedicalProcedureCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class UpdateMedicalProceduresCommandHandler : IRequestHandler<UpdateMedicalProcedureCommand, RequestResponse>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public UpdateMedicalProceduresCommandHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public async Task<RequestResponse> Handle(UpdateMedicalProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalProcedureservice.UpdateMedicalProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateMedicalProcedureCommandValidator : AbstractValidator<UpdateMedicalProcedureCommand>
    {
        public UpdateMedicalProcedureCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
