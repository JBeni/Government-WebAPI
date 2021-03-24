using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Queries
{
    public class GetMedicalCenterProceduresQuery : IRequest<List<MedicalCenterProceduresResponse>>
    {
        public string County { get; set; }
    }

    public class GetMedicalCenterProceduresQueryHandler : IRequestHandler<GetMedicalCenterProceduresQuery, List<MedicalCenterProceduresResponse>>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public GetMedicalCenterProceduresQueryHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public Task<List<MedicalCenterProceduresResponse>> Handle(GetMedicalCenterProceduresQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterProcedureService.GetMedicalCenterProcedures(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class MedicalCenterProceduresResponse : IMapFrom<MedicalCenterProcedure>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<MedicalCenterProcedure, MedicalCenterProceduresResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
