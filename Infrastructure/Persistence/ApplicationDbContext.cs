﻿namespace GovernmentSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
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
        public DbSet<PolicePayment> PolicePayments { get; set; }
        public DbSet<CityPayment> CityPayments { get; set; }
        public DbSet<CitizenRecord> CitizenRecords { get; set; }
        public DbSet<PoliceReportProblem> PoliceReportProblems { get; set; }
        public DbSet<CitizenRequest> CitizenRequests { get; set; }
        public DbSet<DriverLicense> DriverLicenses { get; set; }
        public DbSet<Regularization> Regularizations { get; set; }
        public DbSet<DriverLicenseCategory> DriverLicenseCategories { get; set; }
        public DbSet<IdentityCardAppointment> IdentityCardAppointments { get; set; }
        public DbSet<IdentityCard> IdentityCards { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<CityReportProblem> CityReportProblems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<CityHall> CityHalls { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PublicServantCityHall> PublicServantCityHalls { get; set; }
        public DbSet<CitizenMedicalHistory> CitizenMedicalHistories { get; set; }
        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }
        public DbSet<MedicalCenter> MedicalCenters { get; set; }
        public DbSet<MedicalCenterProcedure> MedicalCenterProcedures { get; set; }
        public DbSet<MedicalPayment> MedicalPayments { get; set; }
        public DbSet<MedicalProcedure> MedicalProcedures { get; set; }
        public DbSet<PublicServantMedicalCenter> PublicServantMedicalCenters { get; set; }
        public DbSet<PublicServantPoliceStation> PublicServantPoliceStations { get; set; }
        public DbSet<PublicServantSeriousFraudOffice> PublicServantSeriousFraudOffices { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<PoliceStation> PoliceStations { get; set; }
        public DbSet<FraudOfficeReportProblem> FraudOfficeReportProblems { get; set; }
        public DbSet<SeriousFraudOffice> SeriousFraudOffices { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditEntity> entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.EntryCreatedBy = _currentUserService.UserId.ToString();
                        entry.Entity.EntryCreated = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.EntryLastModifiedBy = _currentUserService.UserId.ToString();
                        entry.Entity.EntryLastModified = _dateTime.Now;
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
            builder.ApplyConfiguration(new CitizenRecordConfiguration());
            builder.ApplyConfiguration(new CitizenRequestConfiguration());
            builder.ApplyConfiguration(new CityHallConfiguration());
            builder.ApplyConfiguration(new PaymentHistoryConfiguration());
            builder.ApplyConfiguration(new InvoiceConfiguration());
            builder.ApplyConfiguration(new CitizenDriverLicenseCategoryConfiguration());
            builder.ApplyConfiguration(new DriverLicenseCategoryConfiguration());
            builder.ApplyConfiguration(new DriverLicenseConfiguration());
            builder.ApplyConfiguration(new IdentityCardAppointmentConfiguration());
            builder.ApplyConfiguration(new IdentityCardConfiguration());
            builder.ApplyConfiguration(new MedicalAppointmentConfiguration());
            builder.ApplyConfiguration(new MedicalCenterConfiguration());
            builder.ApplyConfiguration(new MedicalCenterProcedureConfiguration());
            builder.ApplyConfiguration(new MedicalPaymentConfiguration());
            builder.ApplyConfiguration(new MedicalProcedureConfiguration());
            builder.ApplyConfiguration(new TaxConfiguration());
            builder.ApplyConfiguration(new PassportConfiguration());
            builder.ApplyConfiguration(new PolicePaymentConfiguration());
            builder.ApplyConfiguration(new PoliceStationConfiguration());
            builder.ApplyConfiguration(new RegularizationConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new PropertyConfiguration());
            builder.ApplyConfiguration(new FraudOfficeReportProblemConfiguration());
            builder.ApplyConfiguration(new PropertyTypeConfiguration());
            builder.ApplyConfiguration(new PublicServantCityHallConfiguration());
            builder.ApplyConfiguration(new PublicServantMedicalCenterConfiguration());
            builder.ApplyConfiguration(new PublicServantPoliceStationConfiguration());
            builder.ApplyConfiguration(new PublicServantSeriousFraudOfficeConfiguration());
            builder.ApplyConfiguration(new CityReportProblemConfiguration());
            builder.ApplyConfiguration(new SeriousFraudOfficeConfiguration());
        }
    }
}
