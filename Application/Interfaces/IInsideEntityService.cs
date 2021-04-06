using GovernmentSystem.Domain.Entities.Citizens;
using GovernmentSystem.Domain.Entities.CityHalls;
using GovernmentSystem.Domain.Entities.Medicals;
using GovernmentSystem.Domain.Entities.PoliceStations;
using GovernmentSystem.Domain.Entities.SeriousFraudOffices;
using System;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IInsideEntityService
    {
        Address GetAddressById(Guid identifier);
        AddressType GetAddressTypeById(Guid identifier);
        BirthCertificate GetBirthCertificateById(Guid identifier);
        CitizenDriverLicenseCategory GetCitizenDriverLicenseCategoryById(Guid identifier);
        CitizenMedicalHistory GetCitizenMedicalHistoryById(Guid identifier);
        CitizenRequest GetCitizenRequestById(Guid identifier);
        Citizen GetCitizenById(Guid identifier);
        CityHall GetCityHallById(Guid identifier);
        DriverLicenseCategory GetDriverLicenseCategoryById(Guid identifier);
        DriverLicense GetDriverLicenseById(Guid identifier);
        IdentityCard GetIdentityCardById(Guid identifier);
        MedicalAppointment GetMedicalAppointmentById(Guid identifier);
        MedicalCenterProcedure GetMedicalCenterProcedureById(Guid identifier);
        MedicalCenter GetMedicalCenterById(Guid identifier);
        MedicalPayment GetMedicalPaymentById(Guid identifier);
        MedicalProcedure GetMedicalProcedureById(Guid identifier);
        Passport GetPassportById(Guid identifier);
        PoliceStation GetPoliceStationById(Guid identifier);
        Property GetPropertyById(Guid identifier);
        PropertyType GetPropertyTypeById(Guid identifier);
        PublicServantCityHall GetPublicServantCityHallById(Guid identifier);
        PublicServantMedicalCenter GetPublicServantMedicalCenterById(Guid identifier);
        PublicServantPoliceStation GetPublicServantPoliceStationById(Guid identifier);
        PublicServantSeriousFraudOffice GetPublicServantSeriousFraudOfficeById(Guid identifier);
        CityReportProblem GetCityReportProblemById(Guid identifier);
        SeriousFraudOffice GetSeriousFraudOfficeById(Guid identifier);
    }
}
