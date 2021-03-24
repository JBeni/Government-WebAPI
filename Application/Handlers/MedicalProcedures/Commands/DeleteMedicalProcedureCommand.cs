using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Commands
{
    public class DeleteMedicalProcedureCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class DeleteMedicalProceduresCommandHandler : IRequestHandler<DeleteMedicalProcedureCommand, RequestResponse>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public DeleteMedicalProceduresCommandHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public async Task<RequestResponse> Handle(DeleteMedicalProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalProcedureservice.DeleteMedicalProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteMedicalProcedureCommandValidator : AbstractValidator<DeleteMedicalProcedureCommand>
    {
        public DeleteMedicalProcedureCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
