﻿namespace GovernmentSystem.Infrastructure.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _csvFileBuilder;
        private readonly IInsideEntityService _insideEntityService;

        public CitizenService(IApplicationDbContext dbContext, IMapper mapper,
            ICsvFileBuilder csvFileBuilder,
            IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _csvFileBuilder = csvFileBuilder;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateCitizen(CreateCitizenCommand command, CancellationToken cancellationToken)
        {
            var birthCertificate = _insideEntityService.GetBirthCertificateById(command.BirthCertificateId);
            var userCNP = GenerateCNP(birthCertificate.Item.BirthDate, command.Gender);
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.CNP == userCNP);
            if (citizen != null)
            {
                throw new Exception("The citizen already exists");
            }
            var address = _insideEntityService.GetAddressById(command.HomeAddressId);
            var identityCard = _insideEntityService.GetIdentityCardById(command.IdentityCardId);
            var passport = _insideEntityService.GetPassportById(command.PassportId);
            var driverLicense = _insideEntityService.GetDriverLicenseById(command.DriverLicenseId);
            var cityHallResidence = _insideEntityService.GetCityHallById(command.CityHallResidenceId);
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var publicServantMedicalCenter = _insideEntityService.GetPublicServantMedicalCenterById(command.PublicServantMedicalCenterId);

            var entity = new Citizen
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                CNP = userCNP,
                Age = command.Age,
                Gender = command.Gender,
                DateOfBirth = command.DateOfBirth,
                DateOfDeath = command.DateOfDeath,
                BirthCertificate = birthCertificate.Item,
                HomeAddress = address.Item,
                IdentityCard = identityCard.Item,
                Passport = passport.Item,
                DriverLicense = driverLicense.Item,
                CityHallResidence = cityHallResidence.Item,
                MedicalCenter = medicalCenter.Item,
                PublicServantMedicalCenter = publicServantMedicalCenter.Item
            };

            _dbContext.Citizens.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteCitizen(DeleteCitizenCommand command, CancellationToken cancellationToken)
        {
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizen == null)
            {
                throw new Exception("The citizen does not exists");
            }

            _dbContext.Citizens.Remove(citizen);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(citizen.Identifier);
        }

        public async Task<ExportCitizensVm> ExportCitizensQuery(ExportCitizensQuery query)
        {
            var vm = new ExportCitizensVm();
            var records = await _dbContext.Citizens
                    .ProjectTo<CitizenExport>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            vm.Content = _csvFileBuilder.BuildCitizensFIle(records);
            vm.ContentType = "text/csv";
            vm.FileName = "TodoItems.csv";
            return vm;
        }

        public string GenerateCNP(DateTime dateOfBirth, string userGender)
        {
            var birthYear = dateOfBirth.ToString("yy");
            var birthMonth = dateOfBirth.ToString("MM");
            var birthDay = dateOfBirth.Day;
            var gender = (userGender == "Male" ? "1" : "2").ToString();

            var userCNP = $"{gender}{birthYear}{birthMonth}{birthDay}{new Random().Next(0, 10)}" +
                $"{new Random().Next(0, 10)}{new Random().Next(0, 10)}{new Random().Next(0, 10)}" +
                $"{new Random().Next(0, 10)}{new Random().Next(0, 10)}";
            return userCNP;
        }

        public Result<CitizenResponse> GetCitizenById(GetCitizenByIdQuery query)
        {
            var result = _dbContext.Citizens
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<CitizenResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<CitizenResponse> { Successful = true, Item = result ?? new CitizenResponse() };
        }

        public Result<CitizenResponse> GetCitizens(GetCitizensQuery query)
        {
            var result = _dbContext.Citizens
                .ProjectTo<CitizenResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<CitizenResponse> { Successful = true, Items = result ?? new List<CitizenResponse>() };
        }

        public async Task<RequestResponse> UpdateCitizen(UpdateCitizenCommand command, CancellationToken cancellationToken)
        {
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizen == null)
            {
                throw new Exception("The citizen does not exists");
            }
            var birthCertificate = _insideEntityService.GetBirthCertificateById(command.BirthCertificateId);
            var address = _insideEntityService.GetAddressById(command.HomeAddressId);
            var identityCard = _insideEntityService.GetIdentityCardById(command.IdentityCardId);
            var passport = _insideEntityService.GetPassportById(command.PassportId);
            var driverLicense = _insideEntityService.GetDriverLicenseById(command.DriverLicenseId);
            var cityHallResidence = _insideEntityService.GetCityHallById(command.CityHallResidenceId);
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var publicServantMedicalCenter = _insideEntityService.GetPublicServantMedicalCenterById(command.PublicServantMedicalCenterId);

            citizen.FirstName = command.FirstName;
            citizen.LastName = command.LastName;
            citizen.Age = command.Age;
            citizen.Gender = command.Gender;
            citizen.DateOfBirth = command.DateOfBirth;
            citizen.DateOfDeath = command.DateOfDeath;
            citizen.BirthCertificate = birthCertificate.Item;
            citizen.HomeAddress = address.Item;
            citizen.IdentityCard = identityCard.Item;
            citizen.Passport = passport.Item;
            citizen.DriverLicense = driverLicense.Item;
            citizen.CityHallResidence = cityHallResidence.Item;
            citizen.MedicalCenter = medicalCenter.Item;
            citizen.PublicServantMedicalCenter = publicServantMedicalCenter.Item;

            _dbContext.Citizens.Update(citizen);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(citizen.Identifier);
        }
    }
}
