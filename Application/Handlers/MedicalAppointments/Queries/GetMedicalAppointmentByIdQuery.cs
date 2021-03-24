using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalAppointments.Queries
{
    public class GetMedicalAppointmentByIdQuery : IRequest<MedicalAppointmentResponse>
    {
        public string County { get; set; }
    }

    public class GetMedicalAppointmentByIdQueryHandler : IRequestHandler<GetMedicalAppointmentByIdQuery, MedicalAppointmentResponse>
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;

        public GetMedicalAppointmentByIdQueryHandler(IMedicalAppointmentService medicalAppointmentService)
        {
            _medicalAppointmentService = medicalAppointmentService;
        }

        public Task<MedicalAppointmentResponse> Handle(GetMedicalAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalAppointmentService.GetMedicalAppointmentById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class MedicalAppointmentResponse : IMapFrom<MedicalAppointment>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<MedicalAppointment, MedicalAppointmentResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
