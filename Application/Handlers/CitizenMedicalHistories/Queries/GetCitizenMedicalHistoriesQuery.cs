using GovernmentSystem.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Common.Mappings;
using System.Collections.Generic;
using GovernmentSystem.Domain.Entities.MedicalEntities;

namespace GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Queries
{
    public class GetCitizenMedicalHistoriesQuery : IRequest<List<MedicalHistoriesResponse>>
    {
        public int Id { get; set; }
    }

    public class GetCitizenMedicalHistoriesQueryHandler : IRequestHandler<GetCitizenMedicalHistoriesQuery, List<MedicalHistoriesResponse>>
    {
        private readonly ICitizenMedicalHistoryService _citizenMedicalHistoryService;

        public GetCitizenMedicalHistoriesQueryHandler(ICitizenMedicalHistoryService citizenMedicalHistoryService)
        {
            _citizenMedicalHistoryService = citizenMedicalHistoryService;
        }

        public Task<List<MedicalHistoriesResponse>> Handle(GetCitizenMedicalHistoriesQuery request, CancellationToken cancellationToken)
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

    public class MedicalHistoriesResponse : IMapFrom<CitizenMedicalHistory>
    {
        public void Mapping(Profile profile)
        {
            //profile.CreateMap<CitizenMedicalHistory, MedicalHistoriesResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
