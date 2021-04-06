using GovernmentSystem.Domain.Entities;
using GovernmentSystem.Domain.Entities.Citizens;
using GovernmentSystem.Domain.Entities.CityHalls;
using GovernmentSystem.Domain.Entities.Medicals;
using GovernmentSystem.Domain.Entities.PoliceStations;
using GovernmentSystem.Domain.Entities.SeriousFraudOffices;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<BirthCertificate> BirthCertificates { get; set; }
        DbSet<Citizen> Citizens { get; set; }
        DbSet<CitizenDriverLicenseCategory> CitizenDriverLicenseCategories { get; set; }
        DbSet<PolicePayment> PolicePayments { get; set; }
        DbSet<Tax> Taxes { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Regularization> Regularizations { get; set; }

        DbSet<CityPayment> CityPayments { get; set; }
        DbSet<CitizenRecord> CitizenRecords { get; set; }
        DbSet<CitizenRequest> CitizenRequests { get; set; }
        DbSet<DriverLicense> DriverLicenses { get; set; }
        DbSet<DriverLicenseCategory> DriverLicenseCategories { get; set; }
        DbSet<IdentityCardAppointment> IdentityCardAppointments { get; set; }
        DbSet<IdentityCard> IdentityCards { get; set; }
        DbSet<Passport> Passports { get; set; }
        DbSet<CityReportProblem> CityReportProblems { get; set; }
        DbSet<PoliceReportProblem> PoliceReportProblems { get; set; }

        DbSet<Address> Addresses { get; set; }
        DbSet<AddressType> AddressTypes { get; set; }
        DbSet<CityHall> CityHalls { get; set; }
        DbSet<Property> Properties { get; set; }
        DbSet<PropertyType> PropertyTypes { get; set; }
        DbSet<PublicServantCityHall> PublicServantCityHalls { get; set; }

        DbSet<CitizenMedicalHistory> CitizenMedicalHistories { get; set; }
        DbSet<MedicalAppointment> MedicalAppointments { get; set; }
        DbSet<MedicalCenter> MedicalCenters { get; set; }
        DbSet<MedicalCenterProcedure> MedicalCenterProcedures { get; set; }
        DbSet<MedicalPayment> MedicalPayments { get; set; }
        DbSet<MedicalProcedure> MedicalProcedures { get; set; }
        DbSet<PublicServantMedicalCenter> PublicServantMedicalCenters { get; set; }

        DbSet<PublicServantPoliceStation> PublicServantPoliceStations { get; set; }
        DbSet<PublicServantSeriousFraudOffice> PublicServantSeriousFraudOffices { get; set; }
        DbSet<Invoice> Invoices { get; set; }

        DbSet<PoliceStation> PoliceStations { get; set; }
        DbSet<SeriousFraudOffice> SeriousFraudOffices { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
