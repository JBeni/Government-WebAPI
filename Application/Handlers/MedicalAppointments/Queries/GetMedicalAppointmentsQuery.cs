using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalAppointments.Queries
{
    public class GetMedicalAppointmentsQuery : IRequest<List<MedicalAppointmentsResponse>>
    {
        public string County { get; set; }
    }

    public class GetMedicalAppointmentsQueryHandler : IRequestHandler<GetMedicalAppointmentsQuery, List<MedicalAppointmentsResponse>>
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;

        public GetMedicalAppointmentsQueryHandler(IMedicalAppointmentService medicalAppointmentService)
        {
            _medicalAppointmentService = medicalAppointmentService;
        }

        public Task<List<MedicalAppointmentsResponse>> Handle(GetMedicalAppointmentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalAppointmentService.GetMedicalAppointments(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class MedicalAppointmentsResponse : IMapFrom<MedicalAppointment>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<MedicalAppointment, MedicalAppointmentsResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
