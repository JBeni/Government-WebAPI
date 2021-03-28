﻿using GovernmentSystem.Application.Handlers.Citizens.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.Citizens.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace GovernmentSystem.Infrastructure.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _csvFileBuilder;

        public CitizenService(IApplicationDbContext dbContext, IMapper mapper, ICsvFileBuilder csvFileBuilder)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _csvFileBuilder = csvFileBuilder;
        }

        public async Task<RequestResponse> CreateCitizen(CreateCitizenCommand command, CancellationToken cancellationToken)
        {
            var userCNP = GenerateCNP(command.DateOfBirth.BirthDate, command.Gender);
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
                DateOfBirth = command.DateOfBirth.BirthDate,
            };

            _dbContext.Citizens.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteCitizen(DeleteCitizenCommand command, CancellationToken cancellationToken)
        {
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizen == null)
            {
                throw new Exception("The citizen does not exists");
            }
            citizen.DateOfDeath = command.DateOfDeath;

            _dbContext.Citizens.Update(citizen);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<ExportCitizensVm> ExportCitizensQuery(ExportCitizensQuery query)
        {
            var vm = new ExportCitizensVm();
            var records = await _dbContext.Citizens
                    .ProjectTo<CitizenRecord>(_mapper.ConfigurationProvider)
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

        public CitizenResponse GetCitizenById(GetCitizenByIdQuery query)
        {
            var result = _dbContext.Citizens
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<CitizenResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<CitizenResponse> GetCitizens(GetCitizensQuery query)
        {
            var result = _dbContext.Citizens
                .ProjectTo<CitizenResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateCitizen(UpdateCitizenCommand command, CancellationToken cancellationToken)
        {
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.Identifier == command.Identifier);
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
