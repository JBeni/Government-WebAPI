using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Queries
{
    public class GetMedicalProceduresQuery : IRequest<List<MedicalProceduresResponse>>
    {
        public string County { get; set; }
    }

    public class GetMedicalProceduresQueryHandler : IRequestHandler<GetMedicalProceduresQuery, List<MedicalProceduresResponse>>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public GetMedicalProceduresQueryHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public Task<List<MedicalProceduresResponse>> Handle(GetMedicalProceduresQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalProcedureservice.GetMedicalProcedures(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class MedicalProceduresResponse : IMapFrom<MedicalProcedure>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<MedicalProcedure, MedicalProceduresResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
