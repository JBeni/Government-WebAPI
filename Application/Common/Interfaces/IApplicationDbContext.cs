using GovernmentSystem.Domain.Entities.Citizen;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Citizen> Citizens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
