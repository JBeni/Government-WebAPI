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
    public class GetCitizenMedicalHistoryQuery : IRequest<List<MedicalHistoryResponse>>
    {
        public int Id { get; set; }
    }

    public class GetCitizenMedicalHistoryQueryHandler : IRequestHandler<GetCitizenMedicalHistoryQuery, List<MedicalHistoryResponse>>
    {
        private readonly ICitizenMedicalHistoryService _citizenMedicalHistoryService;

        public GetCitizenMedicalHistoryQueryHandler(ICitizenMedicalHistoryService citizenMedicalHistoryService)
        {
            _citizenMedicalHistoryService = citizenMedicalHistoryService;
        }

        public Task<List<MedicalHistoryResponse>> Handle(GetCitizenMedicalHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenMedicalHistoryService.GetCitizenMedicalHistory(request);
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
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            //    .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
            //    .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
            //    .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
            //    .ForMember(d => d.RoleId, opt => opt.MapFrom(s => s.UserRoles.FirstOrDefault().Role.Id))
            //    .ForMember(d => d.RoleName, opt => opt.MapFrom(s => s.UserRoles.FirstOrDefault().Role.Name));
        }
    }
}
