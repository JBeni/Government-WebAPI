using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Properties.Commands
{
    public class DeletePropertyCommand : IRequest<RequestResponse>
    {
        public string Identifier { get; set; }
    }

    public class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommand, RequestResponse>
    {
        private readonly IPropertyService _propertyService;

        public DeletePropertyCommandHandler(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<RequestResponse> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _propertyService.DeleteProperty(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePropertyCommandValidator : AbstractValidator<DeletePropertyCommand>
    {
        public DeletePropertyCommandValidator()
        {
            RuleFor(v => v.Identifier)
                .NotEmpty()
                .NotNull();
        }
    }
}
