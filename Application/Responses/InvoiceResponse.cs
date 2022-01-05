namespace GovernmentSystem.Application.Responses
{
    public class InvoiceResponse : IMapFrom<Invoice>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstitutionType { get; set; }
        public long AmountToPay { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.InstitutionType, opt => opt.MapFrom(s => s.InstitutionType))
                .ForMember(d => d.AmountToPay, opt => opt.MapFrom(s => s.AmountToPay))
                .ForMember(d => d.IssuedDate, opt => opt.MapFrom(s => s.IssuedDate))
                .ForMember(d => d.DueDate, opt => opt.MapFrom(s => s.DueDate));
        }
    }
}
