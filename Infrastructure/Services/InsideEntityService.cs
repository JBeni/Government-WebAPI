namespace GovernmentSystem.Infrastructure.Services
{
    public class InsideEntityService : IInsideEntityService
    {
        private readonly IApplicationDbContext _dbContext;

        public InsideEntityService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Result<Address> GetAddressById(Guid identifier)
        {
            var result = _dbContext.Addresses
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The address does not exists");
            }
            return new Result<Address> { Successful = true, Item = result ?? new Address() };
        }

        public Result<AddressType> GetAddressTypeById(Guid identifier)
        {
            var result = _dbContext.AddressTypes
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The address type does not exists");
            }
            return new Result<AddressType> { Successful = true, Item = result ?? new AddressType() };
        }

        public Result<BirthCertificate> GetBirthCertificateById(Guid identifier)
        {
            var result = _dbContext.BirthCertificates
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The birth certificate does not exists");
            }
            return new Result<BirthCertificate> { Successful = true, Item = result ?? new BirthCertificate() };
        }

        public Result<Citizen> GetCitizenById(Guid identifier)
        {
            var result = _dbContext.Citizens
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The citizen does not exists");
            }
            return new Result<Citizen> { Successful = true, Item = result ?? new Citizen() };
        }

        public Result<CitizenDriverLicenseCategory> GetCitizenDriverLicenseCategoryById(Guid identifier)
        {
            var result = _dbContext.CitizenDriverLicenseCategories
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The citizen driver license categories does not exists");
            }
            return new Result<CitizenDriverLicenseCategory> { Successful = true, Item = result ?? new CitizenDriverLicenseCategory() };
        }

        public Result<CitizenMedicalHistory> GetCitizenMedicalHistoryById(Guid identifier)
        {
            var result = _dbContext.CitizenMedicalHistories
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The citizen medical history does not exists");
            }
            return new Result<CitizenMedicalHistory> { Successful = true, Item = result ?? new CitizenMedicalHistory() };
        }

        public Result<CitizenRequest> GetCitizenRequestById(Guid identifier)
        {
            var result = _dbContext.CitizenRequests
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The citizen request does not exists");
            }
            return new Result<CitizenRequest> { Successful = true, Item = result ?? new CitizenRequest() };
        }

        public Result<CityHall> GetCityHallById(Guid identifier)
        {
            var result = _dbContext.CityHalls
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The city hall does not exists");
            }
            return new Result<CityHall> { Successful = true, Item = result ?? new CityHall() };
        }

        public Result<DriverLicense> GetDriverLicenseById(Guid identifier)
        {
            var result = _dbContext.DriverLicenses
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The driver license does not exists");
            }
            return new Result<DriverLicense> { Successful = true, Item = result ?? new DriverLicense() };
        }

        public Result<DriverLicenseCategory> GetDriverLicenseCategoryById(Guid identifier)
        {
            var result = _dbContext.DriverLicenseCategories
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The driver license category does not exists");
            }
            return new Result<DriverLicenseCategory> { Successful = true, Item = result ?? new DriverLicenseCategory() };
        }

        public Result<IdentityCard> GetIdentityCardById(Guid identifier)
        {
            var result = _dbContext.IdentityCards
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The identity card does not exists");
            }
            return new Result<IdentityCard> { Successful = true, Item = result ?? new IdentityCard() };
        }

        public Result<MedicalAppointment> GetMedicalAppointmentById(Guid identifier)
        {
            var result = _dbContext.MedicalAppointments
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The medical appointment does not exists");
            }
            return new Result<MedicalAppointment> { Successful = true, Item = result ?? new MedicalAppointment() };
        }

        public Result<MedicalCenter> GetMedicalCenterById(Guid identifier)
        {
            var result = _dbContext.MedicalCenters
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The medical center does not exists");
            }
            return new Result<MedicalCenter> { Successful = true, Item = result ?? new MedicalCenter() };
        }

        public Result<MedicalCenterProcedure> GetMedicalCenterProcedureById(Guid identifier)
        {
            var result = _dbContext.MedicalCenterProcedures
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The medical center procedure does not exists");
            }
            return new Result<MedicalCenterProcedure> { Successful = true, Item = result ?? new MedicalCenterProcedure() };
        }

        public Result<MedicalPayment> GetMedicalPaymentById(Guid identifier)
        {
            var result = _dbContext.MedicalPayments
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The medical payment does not exists");
            }
            return new Result<MedicalPayment> { Successful = true, Item = result ?? new MedicalPayment() };
        }

        public Result<MedicalProcedure> GetMedicalProcedureById(Guid identifier)
        {
            var result = _dbContext.MedicalProcedures
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The medical procedure does not exists");
            }
            return new Result<MedicalProcedure> { Successful = true, Item = result ?? new MedicalProcedure() };
        }

        public Result<Passport> GetPassportById(Guid identifier)
        {
            var result = _dbContext.Passports
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The passport does not exists");
            }
            return new Result<Passport> { Successful = true, Item = result ?? new Passport() };
        }

        public Result<PoliceStation> GetPoliceStationById(Guid identifier)
        {
            var result = _dbContext.PoliceStations
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The police station does not exists");
            }
            return new Result<PoliceStation> { Successful = true, Item = result ?? new PoliceStation() };
        }

        public Result<Property> GetPropertyById(Guid identifier)
        {
            var result = _dbContext.Properties
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The property does not exists");
            }
            return new Result<Property> { Successful = true, Item = result ?? new Property() };
        }

        public Result<PropertyType> GetPropertyTypeById(Guid identifier)
        {
            var result = _dbContext.PropertyTypes
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The property type does not exists");
            }
            return new Result<PropertyType> { Successful = true, Item = result ?? new PropertyType() };
        }

        public Result<PublicServantCityHall> GetPublicServantCityHallById(Guid identifier)
        {
            var result = _dbContext.PublicServantCityHalls
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The public servant city hall does not exists");
            }
            return new Result<PublicServantCityHall> { Successful = true, Item = result ?? new PublicServantCityHall() };
        }

        public Result<PublicServantMedicalCenter> GetPublicServantMedicalCenterById(Guid identifier)
        {
            var result = _dbContext.PublicServantMedicalCenters
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The public servant medical center does not exists");
            }
            return new Result<PublicServantMedicalCenter> { Successful = true, Item = result ?? new PublicServantMedicalCenter() };
        }

        public Result<PublicServantPoliceStation> GetPublicServantPoliceStationById(Guid identifier)
        {
            var result = _dbContext.PublicServantPoliceStations
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The public servant police does not exists");
            }
            return new Result<PublicServantPoliceStation> { Successful = true, Item = result ?? new PublicServantPoliceStation() };
        }

        public Result<PublicServantSeriousFraudOffice> GetPublicServantSeriousFraudOfficeById(Guid identifier)
        {
            var result = _dbContext.PublicServantSeriousFraudOffices
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The public servant serious fraud office does not exists");
            }
            return new Result<PublicServantSeriousFraudOffice> { Successful = true, Item = result ?? new PublicServantSeriousFraudOffice() };
        }

        public Result<CityReportProblem> GetCityReportProblemById(Guid identifier)
        {
            var result = _dbContext.CityReportProblems
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The city hall report problem does not exists");
            }
            return new Result<CityReportProblem> { Successful = true, Item = result ?? new CityReportProblem() };
        }

        public Result<SeriousFraudOffice> GetSeriousFraudOfficeById(Guid identifier)
        {
            var result = _dbContext.SeriousFraudOffices
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The serious fraud office does not exists");
            }
            return new Result<SeriousFraudOffice> { Successful = true, Item = result ?? new SeriousFraudOffice() };
        }

        public Result<Invoice> GetInvoiceById(Guid identifier)
        {
            var result = _dbContext.Invoices
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The invoice does not exists");
            }
            return new Result<Invoice> { Successful = true, Item = result ?? new Invoice() };
        }

        public Result<Company> GetCompanyById(Guid identifier)
        {
            var result = _dbContext.Companies
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The company does not exists");
            }
            return new Result<Company> { Successful = true, Item = result ?? new Company() };
        }
    }
}
