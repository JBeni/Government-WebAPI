using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.BusinessLogic.Interfaces;
using System;

namespace GovernmentSystem.Application.BusinessLogic.Handlers.Citizens.Commands
{
    public class UpdateCitizenCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string CNP { get; set; }
    }

    public class UpdateCitizenCommandHandler : IRequestHandler<UpdateCitizenCommand, RequestResponse>
    {
        private readonly ICitizenService _citizenService;

        public UpdateCitizenCommandHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public async Task<RequestResponse> Handle(UpdateCitizenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _citizenService.UpdateCitizen(request, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateCitizenCommandValidator : AbstractValidator<UpdateCitizenCommand>
    {
        public UpdateCitizenCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .NotEmpty()
                .NotNull();
        }
    }
}
