using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Queries
{
    public class GetMedicalCenterProcedureByIdQuery : IRequest<MedicalCenterProcedureResponse>
    {
        public string County { get; set; }
    }

    public class GetMedicalCenterProcedureByIdQueryHandler : IRequestHandler<GetMedicalCenterProcedureByIdQuery, MedicalCenterProcedureResponse>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public GetMedicalCenterProcedureByIdQueryHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public Task<MedicalCenterProcedureResponse> Handle(GetMedicalCenterProcedureByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterProcedureService.GetMedicalCenterProcedureById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class MedicalCenterProcedureResponse : IMapFrom<MedicalCenterProcedure>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<MedicalCenterProcedure, MedicalCenterProcedureResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
