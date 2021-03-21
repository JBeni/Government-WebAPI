using GovernmentSystem.Application.Handlers.Citizens.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly IApplicationDbContext _dbContext;

        public CitizenService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> AddCitizen(CreateCitizenCommand command, CancellationToken cancellationToken)
        {
            var userCNP = GenerateCNP(command.DateOfBirth, command.Gender);
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.CNP == userCNP);
            if (citizen != null)
            {
                throw new Exception("The citizen already exists");
            }

            var entity = new Citizen
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                CNP = userCNP,
                Age = command.Age,
                Gender = command.Gender,
                DateOfBirth = command.DateOfBirth,
                PlaceOfBirth = command.PlaceOfBirth,
            };

            _dbContext.Citizens.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteCitizen(DeleteCitizenCommand command, CancellationToken cancellationToken)
        {
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.CNP == command.CNP);
            if (citizen == null)
            {
                throw new Exception("The citizen does not exists");
            }

            citizen.DateOfDeath = command.DateOfDeath;

            _dbContext.Citizens.Update(citizen);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return RequestResponse.Success();
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

        public async Task<RequestResponse> UpdateCitizen(UpdateCitizenCommand command, CancellationToken cancellationToken)
        {
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.CNP == command.CNP);
            if (citizen == null)
            {
                throw new Exception("The citizen does not exists");
            }

            citizen.IdentityCard = command.IdentityCard;
            citizen.Passport = command.Passport;
            citizen.DriverLicense = command.DriverLicense;
            citizen.CityHallResidence = command.CityHallResidence;

            _dbContext.Citizens.Update(citizen);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return RequestResponse.Success();
        }
    }
}
