using GovernmentSystem.Application.Common.Exceptions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.BusinessLogic.Citizens.Commands
{
    public class UpdateCitizenCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }

    public class UpdateCitizenCommandHandler : IRequestHandler<UpdateCitizenCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCitizenCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCitizenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Citizens.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Citizen), request.Id);
            }

            entity.FirstName = request.FirstName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
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
