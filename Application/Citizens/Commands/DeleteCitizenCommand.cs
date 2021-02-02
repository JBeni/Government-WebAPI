using GovernmentSystem.Application.Common.Exceptions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Citizens.Commands
{
    public class DeleteCitizenCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCitizenCommandHandler : IRequestHandler<DeleteCitizenCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCitizenCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCitizenCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Citizens.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Citizen), request.Id);
            }

            _context.Citizens.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
