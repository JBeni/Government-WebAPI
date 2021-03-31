using FluentValidation;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Commands
{
    public class DeleteCitizenDriverLicenseCategoryCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteCitizenDriverLicenseCategoryCommandHandler : IRequestHandler<DeleteCitizenDriverLicenseCategoryCommand, RequestResponse>
    {
        private readonly ICitizenDriverLicenseCategoryService _service;

        public DeleteCitizenDriverLicenseCategoryCommandHandler(ICitizenDriverLicenseCategoryService service)
        {
            _service = service;
        }

        public async Task<RequestResponse> Handle(DeleteCitizenDriverLicenseCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteCitizenDriverLicenseCategory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteCitizenDriverLicenseCategoryCommandValidator : AbstractValidator<DeleteCitizenDriverLicenseCategoryCommand>
    {
        public DeleteCitizenDriverLicenseCategoryCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
