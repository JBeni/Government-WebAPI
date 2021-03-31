﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.BirthCertificates.Commands;
using GovernmentSystem.Application.Handlers.BirthCertificates.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class BirthCertificateService : IBirthCertificateService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public BirthCertificateService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateBirthCertificate(CreateBirthCertificateCommand command, CancellationToken cancellationToken)
        {
            var birthCertificate = _dbContext.BirthCertificates.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (birthCertificate != null)
            {
                throw new Exception("The birth certificate already exists");
            }

            var entity = new BirthCertificate
            {
                BirthDate = command.BirthDate,
                BirthPlace = command.BirthPlace,
                Country = command.Country,
                Father = command.Father,
                FirstName = command.FirstName,
                RegistrationDate = command.RegistrationDate,
                LastName = command.LastName,
                Mother = command.Mother,
                PersonalIdentificationNumber = command.PersonalIdentificationNumber,
                RegistrationPlace = command.RegistrationPlace,
                Series = command.Series,
            };

            _dbContext.BirthCertificates.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteBirthCertificate(DeleteBirthCertificateCommand command, CancellationToken cancellationToken)
        {
            var birthCertificate = _dbContext.BirthCertificates.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (birthCertificate != null)
            {
                throw new Exception("The birth certificate does not exists");
            }

            _dbContext.BirthCertificates.Remove(birthCertificate);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public BirthCertificateResponse GetBirthCertificateById(GetBirthCertificateByIdQuery query)
        {
            var result = _dbContext.BirthCertificates
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<BirthCertificateResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<BirthCertificateResponse> GetBirthCertificates(GetBirthCertificatesQuery query)
        {
            var result = _dbContext.BirthCertificates
                .ProjectTo<BirthCertificateResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateBirthCertificate(UpdateBirthCertificateCommand command, CancellationToken cancellationToken)
        {
            var birthCertificate = _dbContext.BirthCertificates.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (birthCertificate != null)
            {
                throw new Exception("The birth certificate does not exists");
            }

            _dbContext.BirthCertificates.Update(birthCertificate);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
