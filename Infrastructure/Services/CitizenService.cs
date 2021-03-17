using GovernmentSystem.Application.BusinessLogic.Handlers.Citizens.Commands;
using GovernmentSystem.Application.BusinessLogic.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Domain.Entities;
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
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.CNP == command.CNP);
            if (citizen != null)
            {
                throw new Exception("The citizen already exists");
            }

            var entity = new Citizen
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth
            };

            _dbContext.Citizens.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateCitizen(UpdateCitizenCommand command, CancellationToken cancellationToken)
        {
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.CNP == command.CNP);
            if (citizen == null)
            {
                throw new Exception("The citizen does not exists");
            }

            citizen.FirstName = command.FirstName;

            _dbContext.Citizens.Update(citizen);
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

        public string GenerateCNP(Citizen citizen)
        {
            var birthYear = citizen.DateOfBirth.ToString("yy");
            var birthMonth = citizen.DateOfBirth.ToString("MM");
            var birthDay = citizen.DateOfBirth.Day;
            var gender = (citizen.Gender == "Male" ? "1" : "2").ToString();

            var userCNP = $"{gender}{birthYear}{birthMonth}{birthDay}{new Random().Next(0, 10)}" +
                $"{new Random().Next(0, 10)}{new Random().Next(0, 10)}{new Random().Next(0, 10)}" +
                $"{new Random().Next(0, 10)}{new Random().Next(0, 10)}";

            return userCNP;
        }
    }
}
