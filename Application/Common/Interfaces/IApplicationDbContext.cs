using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Citizen> Citizens { get; set; }
        DbSet<MedicalCenter> MedicalCenters { get; set; }
        DbSet<CityHall> CityHalls { get; set; }
        DbSet<Property> Properties { get; set; }
        DbSet<CitizenRequest> CitizenRequests { get; set; }
        DbSet<ReportProblem> ReportProblems { get; set; }
        DbSet<MedicalAppointment> MedicalAppointments { get; set; }
        DbSet<CitizenMedicalHistory> CitizenMedicalHistory { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
