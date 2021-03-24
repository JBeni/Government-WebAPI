using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Queries
{
    public class GetCitizenMedicalHistoryByIdQuery : IRequest<MedicalHistoryResponse>
    {
        public int Id { get; set; }
    }

    public class GetCitizenMedicalHistoryQueryHandler : IRequestHandler<GetCitizenMedicalHistoryByIdQuery, MedicalHistoryResponse>
    {
        private readonly ICitizenMedicalHistoryService _citizenMedicalHistoryService;

        public GetCitizenMedicalHistoryQueryHandler(ICitizenMedicalHistoryService citizenMedicalHistoryService)
        {
            _citizenMedicalHistoryService = citizenMedicalHistoryService;
        }

        public Task<MedicalHistoryResponse> Handle(GetCitizenMedicalHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenMedicalHistoryService.GetCitizenMedicalHistoryById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the medical history of citizen", ex);
            }
        }
    }

    public class MedicalHistoryResponse : IMapFrom<CitizenMedicalHistory>
    {
        public void Mapping(Profile profile)
        {
            //profile.CreateMap<CitizenMedicalHistory, MedicalHistoryResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
