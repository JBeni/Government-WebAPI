namespace GovernmentSystem.Application.Interfaces
{
    public interface IInsideEntityService
    {
        Result<Address> GetAddressById(Guid identifier);
        Result<AddressType> GetAddressTypeById(Guid identifier);
        Result<BirthCertificate> GetBirthCertificateById(Guid identifier);
        Result<CitizenDriverLicenseCategory> GetCitizenDriverLicenseCategoryById(Guid identifier);
        Result<CitizenMedicalHistory> GetCitizenMedicalHistoryById(Guid identifier);
        Result<CitizenRequest> GetCitizenRequestById(Guid identifier);
        Result<Citizen> GetCitizenById(Guid identifier);
        Result<CityHall> GetCityHallById(Guid identifier);
        Result<Company> GetCompanyById(Guid identifier);
        Result<DriverLicenseCategory> GetDriverLicenseCategoryById(Guid identifier);
        Result<DriverLicense> GetDriverLicenseById(Guid identifier);
        Result<IdentityCard> GetIdentityCardById(Guid identifier);
        Result<Invoice> GetInvoiceById(Guid identifier);
        Result<MedicalAppointment> GetMedicalAppointmentById(Guid identifier);
        Result<MedicalCenterProcedure> GetMedicalCenterProcedureById(Guid identifier);
        Result<MedicalCenter> GetMedicalCenterById(Guid identifier);
        Result<MedicalPayment> GetMedicalPaymentById(Guid identifier);
        Result<MedicalProcedure> GetMedicalProcedureById(Guid identifier);
        Result<Passport> GetPassportById(Guid identifier);
        Result<PoliceStation> GetPoliceStationById(Guid identifier);
        Result<Property> GetPropertyById(Guid identifier);
        Result<PropertyType> GetPropertyTypeById(Guid identifier);
        Result<PublicServantCityHall> GetPublicServantCityHallById(Guid identifier);
        Result<PublicServantMedicalCenter> GetPublicServantMedicalCenterById(Guid identifier);
        Result<PublicServantPoliceStation> GetPublicServantPoliceStationById(Guid identifier);
        Result<PublicServantSeriousFraudOffice> GetPublicServantSeriousFraudOfficeById(Guid identifier);
        Result<CityReportProblem> GetCityReportProblemById(Guid identifier);
        Result<SeriousFraudOffice> GetSeriousFraudOfficeById(Guid identifier);
    }
}
