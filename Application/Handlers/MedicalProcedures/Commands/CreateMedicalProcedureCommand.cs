using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Commands
{
    public class CreateMedicalProcedureCommand : IRequest<RequestResponse>
    {
        public string UniqueIdentifier { get; set; }
    }

    public class CreateMedicalProceduresCommandHandler : IRequestHandler<CreateMedicalProcedureCommand, RequestResponse>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public CreateMedicalProceduresCommandHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public async Task<RequestResponse> Handle(CreateMedicalProcedureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _medicalProcedureservice.CreateMedicalProcedure(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateMedicalProcedureCommandValidator : AbstractValidator<CreateMedicalProcedureCommand>
    {
        public CreateMedicalProcedureCommandValidator()
        {
            RuleFor(v => v.UniqueIdentifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
