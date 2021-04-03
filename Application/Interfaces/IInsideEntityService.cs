using GovernmentSystem.Domain.Entities;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
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
        MedicalPaymentHistory GetMedicalPaymentHistoryById(Guid identifier);
        MedicalProcedure GetMedicalProcedureById(Guid identifier);
        Passport GetPassportById(Guid identifier);
        PoliceStation GetPoliceStationById(Guid identifier);
        Property GetPropertyById(Guid identifier);
        PropertyType GetPropertyTypeById(Guid identifier);
        PublicServantCityHall GetPublicServantCityHallById(Guid identifier);
        PublicServantMedicalCenter GetPublicServantMedicalCenterById(Guid identifier);
        PublicServantPolice GetPublicServantPoliceById(Guid identifier);
        PublicServantSeriousFraudOffice GetPublicServantSeriousFraudOfficeById(Guid identifier);
        ReportProblem GetReportProblemById(Guid identifier);
        SeriousFraudOffice GetSeriousFraudOfficeById(Guid identifier);
    }
}
