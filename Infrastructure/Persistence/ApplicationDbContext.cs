using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using GovernmentSystem.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext , IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(
            DbContextOptions options,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<MedicalCenter> MedicalCenters { get; set; }
        public DbSet<CityHall> CityHalls { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<CitizenRequest> CitizenRequests { get; set; }
        public DbSet<ReportProblem> ReportProblems { get; set; }
        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }
        public DbSet<CitizenMedicalHistory> CitizenMedicalHistory { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DbEntryCreatedBy = _currentUserService.UserId.ToString();
                        entry.Entity.DbEntryCreated = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.DbEntryLastModifiedBy = _currentUserService.UserId.ToString();
                        entry.Entity.DbEntryLastModified = _dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.ApplyConfiguration(new CitizenConfiguration());
        }
    }
}
