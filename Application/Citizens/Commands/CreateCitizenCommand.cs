using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Citizens.Commands
{
    public class CreateCitizenCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class CreateCitizenCommandHandler : IRequestHandler<CreateCitizenCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCitizenCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCitizenCommand request, CancellationToken cancellationToken)
        {
            var entity = new Citizen
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth
            };

            _context.Citizens.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

    public class CreateCitizenCommandValidator : AbstractValidator<CreateCitizenCommand>
    {
        public CreateCitizenCommandValidator()
        {
            RuleFor(v => v.DateOfBirth)
                .NotEmpty()
                .NotNull();
        }
    }
}
