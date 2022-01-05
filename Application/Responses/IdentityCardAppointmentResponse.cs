namespace GovernmentSystem.Application.Responses
{
    public class IdentityCardAppointmentResponse : IMapFrom<IdentityCardAppointment>
    {
        public Guid Identifier { get; set; }
        public string Reason { get; set; }
        public DateTime AppointmentDay { get; set; }
        public string AdditionalInformation { get; set; }
        public Citizen Citizen { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityCardAppointment, IdentityCardAppointmentResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Reason, opt => opt.MapFrom(s => s.Reason))
                .ForMember(d => d.AppointmentDay, opt => opt.MapFrom(s => s.AppointmentDay))
                .ForMember(d => d.AdditionalInformation, opt => opt.MapFrom(s => s.AdditionalInformation))
                .ForMember(d => d.Citizen, opt => opt.MapFrom(s => s.Citizen));
        }
    }
}
