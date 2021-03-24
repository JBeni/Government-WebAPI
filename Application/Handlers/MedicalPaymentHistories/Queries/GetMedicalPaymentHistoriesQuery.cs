using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Queries
{
    public class GetMedicalPaymentHistoriesQuery : IRequest<List<MedicalPaymentHistoriesResponse>>
    {
        public string County { get; set; }
    }

    public class GetMedicalPaymentHistoriesQueryHandler : IRequestHandler<GetMedicalPaymentHistoriesQuery, List<MedicalPaymentHistoriesResponse>>
    {
        private readonly IMedicalPaymentHistoryService _medicalPaymentHistoryService;

        public GetMedicalPaymentHistoriesQueryHandler(IMedicalPaymentHistoryService medicalPaymentHistoryService)
        {
            _medicalPaymentHistoryService = medicalPaymentHistoryService;
        }

        public Task<List<MedicalPaymentHistoriesResponse>> Handle(GetMedicalPaymentHistoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalPaymentHistoryService.GetMedicalPaymentHistories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class MedicalPaymentHistoriesResponse : IMapFrom<MedicalPaymentHistory>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<MedicalPaymentHistory, MedicalPaymentHistoriesResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
