using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
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
}
