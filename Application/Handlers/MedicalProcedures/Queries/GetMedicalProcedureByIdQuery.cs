using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Queries
{
    public class GetMedicalProcedureByIdQuery : IRequest<MedicalProcedureResponse>
    {
        public string County { get; set; }
    }

    public class GetMedicalProcedureByIdQueryHandler : IRequestHandler<GetMedicalProcedureByIdQuery, MedicalProcedureResponse>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public GetMedicalProcedureByIdQueryHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public Task<MedicalProcedureResponse> Handle(GetMedicalProcedureByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalProcedureservice.GetMedicalProcedureById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class MedicalProcedureResponse : IMapFrom<MedicalProcedure>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<MedicalProcedure, MedicalProcedureResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
