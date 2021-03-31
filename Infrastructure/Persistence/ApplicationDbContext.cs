using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
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

        public DbSet<BirthCertificate> BirthCertificates { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<CitizenDriverLicenseCategory> CitizenDriverLicenseCategories { get; set; }
        public DbSet<CitizenRequest> CitizenRequests { get; set; }
        public DbSet<DriverLicense> DriverLicenses { get; set; }
        public DbSet<DriverLicenseCategory> DriverLicenseCategories { get; set; }
        public DbSet<IdentityCard> IdentityCards { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<ReportProblem> ReportProblems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<CityHall> CityHalls { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PublicServantCityHall> PublicServantCityHalls { get; set; }
        public DbSet<CitizenMedicalHistory> CitizenMedicalHistories { get; set; }
        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }
        public DbSet<MedicalCenter> MedicalCenters { get; set; }
        public DbSet<MedicalCenterProcedure> MedicalCenterProcedures { get; set; }
        public DbSet<MedicalPaymentHistory> MedicalPaymentHistories { get; set; }
        public DbSet<MedicalProcedure> MedicalProcedures { get; set; }
        public DbSet<PublicServantGP> PublicServantGPs { get; set; }
        public DbSet<PublicServantPolice> PublicServantPolices { get; set; }
        public DbSet<PublicServantSFO> PublicServantSFOs { get; set; }
        public DbSet<PoliceStation> PoliceStations { get; set; }
        public DbSet<SeriousFraudOffice> SeriousFraudOffices { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.AuditEntryCreatedBy = _currentUserService.UserId.ToString();
                        entry.Entity.AuditEntryCreated = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.AuditEntryLastModifiedBy = _currentUserService.UserId.ToString();
                        entry.Entity.AuditEntryLastModified = _dateTime.Now;
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

            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new AddressTypeConfiguration());
            builder.ApplyConfiguration(new BirthCertificateConfiguration());
            builder.ApplyConfiguration(new CitizenConfiguration());
            builder.ApplyConfiguration(new CitizenMedicalHistoryConfiguration());
            builder.ApplyConfiguration(new CitizenRequestConfiguration());
            builder.ApplyConfiguration(new CityHallConfiguration());
            builder.ApplyConfiguration(new CitizenDriverLicenseCategoryConfiguration());
            builder.ApplyConfiguration(new DriverLicenseCategoryConfiguration());
            builder.ApplyConfiguration(new DriverLicenseConfiguration());
            builder.ApplyConfiguration(new IdentityCardConfiguration());
            builder.ApplyConfiguration(new MedicalAppointmentConfiguration());
            builder.ApplyConfiguration(new MedicalCenterConfiguration());
            builder.ApplyConfiguration(new MedicalCenterProcedureConfiguration());
            builder.ApplyConfiguration(new MedicalPaymentHistoryConfiguration());
            builder.ApplyConfiguration(new MedicalProcedureConfiguration());
            builder.ApplyConfiguration(new PassportConfiguration());
            builder.ApplyConfiguration(new PoliceStationConfiguration());
            builder.ApplyConfiguration(new PropertyConfiguration());
            builder.ApplyConfiguration(new PropertyTypeConfiguration());
            builder.ApplyConfiguration(new PublicServantCityHallConfiguration());
            builder.ApplyConfiguration(new PublicServantGPConfiguration());
            builder.ApplyConfiguration(new PublicServantPoliceConfiguration());
            builder.ApplyConfiguration(new PublicServantSFOConfiguration());
            builder.ApplyConfiguration(new ReportProblemConfiguration());
            builder.ApplyConfiguration(new SeriousFraudOfficeConfiguration());
        }
    }
}
