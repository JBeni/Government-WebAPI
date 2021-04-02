﻿using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
using System;
using System.Linq;

namespace GovernmentSystem.Infrastructure.Services
{
    public class InsideEntityService : IInsideEntityService
    {
        private readonly IApplicationDbContext _dbContext;

        public InsideEntityService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Address GetAddressById(Guid identifier)
        {
            var result = _dbContext.Addresses
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The address does not exists");
            }
            return result;
        }

        public AddressType GetAddressTypeById(Guid identifier)
        {
            var result = _dbContext.AddressTypes
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The address type does not exists");
            }
            return result;
        }

        public BirthCertificate GetBirthCertificateById(Guid identifier)
        {
            var result = _dbContext.BirthCertificates
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The birth certificate does not exists");
            }
            return result;
        }

        public Citizen GetCitizenById(Guid identifier)
        {
            var result = _dbContext.Citizens
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The citizen does not exists");
            }
            return result;
        }

        public CitizenDriverLicenseCategory GetCitizenDriverLicenseCategoryById(Guid identifier)
        {
            var result = _dbContext.CitizenDriverLicenseCategories
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The citizen driver license categories does not exists");
            }
            return result;
        }

        public CitizenMedicalHistory GetCitizenMedicalHistoryById(Guid identifier)
        {
            var result = _dbContext.CitizenMedicalHistories
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The citizen medical history does not exists");
            }
            return result;
        }

        public CitizenRequest GetCitizenRequestById(Guid identifier)
        {
            var result = _dbContext.CitizenRequests
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The citizen request does not exists");
            }
            return result;
        }

        public CityHall GetCityHallById(Guid identifier)
        {
            var result = _dbContext.CityHalls
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The city hall does not exists");
            }
            return result;
        }

        public DriverLicense GetDriverLicenseById(Guid identifier)
        {
            var result = _dbContext.DriverLicenses
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The driver license does not exists");
            }
            return result;
        }

        public DriverLicenseCategory GetDriverLicenseCategoryById(Guid identifier)
        {
            var result = _dbContext.DriverLicenseCategories
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The driver license category does not exists");
            }
            return result;
        }

        public IdentityCard GetIdentityCardById(Guid identifier)
        {
            var result = _dbContext.IdentityCards
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The identity card does not exists");
            }
            return result;
        }

        public MedicalAppointment GetMedicalAppointmentById(Guid identifier)
        {
            var result = _dbContext.MedicalAppointments
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The medical appointment does not exists");
            }
            return result;
        }

        public MedicalCenter GetMedicalCenterById(Guid identifier)
        {
            var result = _dbContext.MedicalCenters
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The medical center does not exists");
            }
            return result;
        }

        public MedicalCenterProcedure GetMedicalCenterProcedureById(Guid identifier)
        {
            var result = _dbContext.MedicalCenterProcedures
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The medical center procedure does not exists");
            }
            return result;
        }

        public MedicalPaymentHistory GetMedicalPaymentHistoryById(Guid identifier)
        {
            var result = _dbContext.MedicalPaymentHistories
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The medical payment history does not exists");
            }
            return result;
        }

        public MedicalProcedure GetMedicalProcedureById(Guid identifier)
        {
            var result = _dbContext.MedicalProcedures
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The medical procedure does not exists");
            }
            return result;
        }

        public Passport GetPassportById(Guid identifier)
        {
            var result = _dbContext.Passports
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The passport does not exists");
            }
            return result;
        }

        public PoliceStation GetPoliceStationById(Guid identifier)
        {
            var result = _dbContext.PoliceStations
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The police station does not exists");
            }
            return result;
        }

        public Property GetPropertyById(Guid identifier)
        {
            var result = _dbContext.Properties
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The property does not exists");
            }
            return result;
        }

        public PropertyType GetPropertyTypeById(Guid identifier)
        {
            var result = _dbContext.PropertyTypes
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The property type does not exists");
            }
            return result;
        }

        public PublicServantCityHall GetPublicServantCityHallById(Guid identifier)
        {
            var result = _dbContext.PublicServantCityHalls
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The public servant city hall does not exists");
            }
            return result;
        }

        public PublicServantGP GetPublicServantGPById(Guid identifier)
        {
            var result = _dbContext.PublicServantGPs
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The public servant GP does not exists");
            }
            return result;
        }

        public PublicServantPolice GetPublicServantPoliceById(Guid identifier)
        {
            var result = _dbContext.PublicServantPolices
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The public servant police does not exists");
            }
            return result;
        }

        public PublicServantSFO GetPublicServantSFOById(Guid identifier)
        {
            var result = _dbContext.PublicServantSFOs
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The public servant SFO does not exists");
            }
            return result;
        }

        public ReportProblem GetReportProblemById(Guid identifier)
        {
            var result = _dbContext.ReportProblems
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The report problem does not exists");
            }
            return result;
        }

        public SeriousFraudOffice GetSeriousFraudOfficeById(Guid identifier)
        {
            var result = _dbContext.SeriousFraudOffices
                .Where(v => v.Identifier == identifier)
                .FirstOrDefault();
            if (result == null)
            {
                throw new Exception("The serious fraud office does not exists");
            }
            return result;
        }
    }
}