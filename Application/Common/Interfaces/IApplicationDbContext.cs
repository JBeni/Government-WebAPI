using GovernmentSystem.Domain.Entities;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<BirthCertificate> BirthCertificates { get; set; }
        DbSet<Citizen> Citizens { get; set; }

        DbSet<CitizenRequest> CitizenRequests { get; set; }
        DbSet<DriverLicense> DriverLicenses { get; set; }
        DbSet<DriverLicenseCategory> DriverLicenseCategories { get; set; }
        DbSet<IdentityCard> IdentityCards { get; set; }
        DbSet<Passport> Passports { get; set; }
        DbSet<ReportProblem> ReportProblems { get; set; }

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
        DbSet<MedicalPaymentHistory> MedicalPaymentHistories { get; set; }
        DbSet<MedicalProcedure> MedicalProcedures { get; set; }
        DbSet<PublicServantGP> PublicServantGPs { get; set; }

        DbSet<PublicServantPolice> PublicServantPolices { get; set; }
        DbSet<PublicServantSFO> PublicServantSFOs { get; set; }

        DbSet<PoliceStation> PoliceStations { get; set; }
        DbSet<SeriousFraudOffice> SeriousFraudOffices { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
