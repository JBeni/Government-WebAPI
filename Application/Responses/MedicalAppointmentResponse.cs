namespace GovernmentSystem.Application.Responses
{
    public class MedicalAppointmentResponse : IMapFrom<MedicalAppointment>
    {
        public Guid Identifier { get; set; }
        public string Symptoms { get; set; }
        public DateTime AppointmentDay { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }
        public Citizen Citizen { get; set; }
        public PublicServantMedicalCenter PublicServantMedicalCenter { get; set; }
        public MedicalCenter MedicalCenter { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MedicalAppointment, MedicalAppointmentResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Symptoms, opt => opt.MapFrom(s => s.Symptoms))
                .ForMember(d => d.AppointmentDay, opt => opt.MapFrom(s => s.AppointmentDay))
                .ForMember(d => d.MedicalProcedure, opt => opt.MapFrom(s => s.MedicalProcedure))
                .ForMember(d => d.Citizen, opt => opt.MapFrom(s => s.Citizen))
                .ForMember(d => d.PublicServantMedicalCenter, opt => opt.MapFrom(s => s.PublicServantMedicalCenter))
                .ForMember(d => d.MedicalCenter, opt => opt.MapFrom(s => s.MedicalCenter));
        }
    }
}
