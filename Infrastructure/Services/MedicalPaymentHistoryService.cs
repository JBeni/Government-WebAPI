﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Commands;
using GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalPaymentHistoryService : IMedicalPaymentHistoryService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insiderEntityService;

        public MedicalPaymentHistoryService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insiderEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insiderEntityService = insiderEntityService;
        }

        public async Task<RequestResponse> CreateMedicalPaymentHistory(CreateMedicalPaymentHistoryCommand command, CancellationToken cancellationToken)
        {
            var medicalPaymentHistory = _dbContext.MedicalPaymentHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalPaymentHistory != null)
            {
                throw new Exception("The medical payment history already exists");
            }
            var citizenWhoBenefit = _insiderEntityService.GetCitizenById(command.CitizenWhoBenefitId);
            var citizenWhoPaid = _insiderEntityService.GetCitizenById(command.CitizenWhoPaidId);
            var medicalCenter = _insiderEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var medicalProcedure = _insiderEntityService.GetMedicalProcedureById(command.MedicalProcedureId);
            var publicServantGP = _insiderEntityService.GetPublicServantGPById(command.PublicServantGPId);

            var entity = new MedicalPaymentHistory
            {
                AmountPaid = command.AmountPaid,
                AmountToPay = command.AmountToPay,
                DateOfPayment = command.DateOfPayment,
                CitizenWhoBenefit = citizenWhoBenefit,
                CitizenWhoPaid = citizenWhoPaid,
                MedicalCenter = medicalCenter,
                MedicalProcedure = medicalProcedure,
                PublicServantGP = publicServantGP
            };

            _dbContext.MedicalPaymentHistories.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteMedicalPaymentHistory(DeleteMedicalPaymentHistoryCommand command, CancellationToken cancellationToken)
        {
            var medicalPaymentHistory = _dbContext.MedicalPaymentHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalPaymentHistory != null)
            {
                throw new Exception("The medical payment history does not exists");
            }

            _dbContext.MedicalPaymentHistories.Remove(medicalPaymentHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public List<MedicalPaymentHistoryResponse> GetMedicalPaymentHistories(GetMedicalPaymentHistoriesQuery query)
        {
            var result = _dbContext.MedicalPaymentHistories
                .ProjectTo<MedicalPaymentHistoryResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public MedicalPaymentHistoryResponse GetMedicalPaymentHistoryById(GetMedicalPaymentHistoryByIdQuery query)
        {
            var result = _dbContext.MedicalPaymentHistories
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalPaymentHistoryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public async Task<RequestResponse> UpdateMedicalPaymentHistory(UpdateMedicalPaymentHistoryCommand command, CancellationToken cancellationToken)
        {
            var medicalPaymentHistory = _dbContext.MedicalPaymentHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalPaymentHistory != null)
            {
                throw new Exception("The medical payment history does not exists");
            }
            var citizenWhoBenefit = _insiderEntityService.GetCitizenById(command.CitizenWhoBenefitId);
            var citizenWhoPaid = _insiderEntityService.GetCitizenById(command.CitizenWhoPaidId);
            var medicalCenter = _insiderEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var medicalProcedure = _insiderEntityService.GetMedicalProcedureById(command.MedicalProcedureId);
            var publicServantGP = _insiderEntityService.GetPublicServantGPById(command.PublicServantGPId);

            medicalPaymentHistory.AmountPaid = command.AmountPaid;
            medicalPaymentHistory.AmountToPay = command.AmountToPay;
            medicalPaymentHistory.DateOfPayment = command.DateOfPayment;
            medicalPaymentHistory.CitizenWhoBenefit = citizenWhoBenefit;
            medicalPaymentHistory.CitizenWhoPaid = citizenWhoPaid;
            medicalPaymentHistory.MedicalCenter = medicalCenter;
            medicalPaymentHistory.MedicalProcedure = medicalProcedure;
            medicalPaymentHistory.PublicServantGP = publicServantGP;

            _dbContext.MedicalPaymentHistories.Update(medicalPaymentHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
