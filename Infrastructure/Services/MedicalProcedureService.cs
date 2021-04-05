using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.MedicalProcedures.Commands;
using GovernmentSystem.Application.Handlers.MedicalProcedures.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using GovernmentSystem.Domain.Entities.Medicals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalProcedureService : IMedicalProcedureService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MedicalProcedureService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateMedicalProcedure(CreateMedicalProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalPaymentHistory = _dbContext.MedicalProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalPaymentHistory != null)
            {
                throw new Exception("The medical procedure already exists");
            }
            var entity = new MedicalProcedure
            {
                AdditionalInformation = command.AdditionalInformation,
                Price = command.Price,
                ProcedureDuration = command.ProcedureDuration,
                ProcedureName = command.ProcedureName
            };

            _dbContext.MedicalProcedures.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteMedicalProcedure(DeleteMedicalProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalPaymentHistory = _dbContext.MedicalProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalPaymentHistory != null)
            {
                throw new Exception("The medical procedure does not exists");
            }

            _dbContext.MedicalProcedures.Remove(medicalPaymentHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public MedicalProcedureResponse GetMedicalProcedureById(GetMedicalProcedureByIdQuery query)
        {
            var result = _dbContext.MedicalProcedures
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalProcedureResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<MedicalProcedureResponse> GetMedicalProcedures(GetMedicalProceduresQuery query)
        {
            var result = _dbContext.MedicalProcedures
                .ProjectTo<MedicalProcedureResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateMedicalProcedure(UpdateMedicalProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalPaymentHistory = _dbContext.MedicalProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalPaymentHistory != null)
            {
                throw new Exception("The medical procedure does not exists");
            }
            medicalPaymentHistory.AdditionalInformation = command.AdditionalInformation;
            medicalPaymentHistory.Price = command.Price;
            medicalPaymentHistory.ProcedureDuration = command.ProcedureDuration;
            medicalPaymentHistory.ProcedureName = command.ProcedureName;

            _dbContext.MedicalProcedures.Update(medicalPaymentHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
