﻿using GovernmentSystem.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Queries
{
    public class GetCitizenMedicalHistoriesQuery : IRequest<List<CitizenMedicalHistoryResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCitizenMedicalHistoriesQueryHandler : IRequestHandler<GetCitizenMedicalHistoriesQuery, List<CitizenMedicalHistoryResponse>>
    {
        private readonly ICitizenMedicalHistoryService _citizenMedicalHistoryService;

        public GetCitizenMedicalHistoriesQueryHandler(ICitizenMedicalHistoryService citizenMedicalHistoryService)
        {
            _citizenMedicalHistoryService = citizenMedicalHistoryService;
        }

        public Task<List<CitizenMedicalHistoryResponse>> Handle(GetCitizenMedicalHistoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenMedicalHistoryService.GetCitizenMedicalHistories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the medical history of citizen", ex);
            }
        }
    }
}
