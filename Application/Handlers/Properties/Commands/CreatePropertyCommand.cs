using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Properties.Commands
{
    public class CreatePropertyCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public long Size { get; set; }
        public string UnitOfMeasure { get; set; }
        public string ValueAtBuying { get; set; }
        public string CurrentValue { get; set; }
        public int TypeId { get; set; }
        public int AddressId { get; set; }
        public Guid CityHallId { get; set; }
    }

    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, RequestResponse>
    {
        private readonly IPropertyService _propertyService;

        public CreatePropertyCommandHandler(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<RequestResponse> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _propertyService.CreateProperty(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Size).NotEmpty().NotNull();
            RuleFor(v => v.UnitOfMeasure).NotEmpty().NotNull();
            RuleFor(v => v.ValueAtBuying).NotEmpty().NotNull();
            RuleFor(v => v.CurrentValue).NotEmpty().NotNull();
            RuleFor(v => v.TypeId).NotEmpty().NotNull();
            RuleFor(v => v.AddressId).NotEmpty().NotNull();
            RuleFor(v => v.CityHallId).NotEmpty().NotNull();
        }
    }
}
