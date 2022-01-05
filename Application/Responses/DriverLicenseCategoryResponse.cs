namespace GovernmentSystem.Application.Responses
{
    public class DriverLicenseCategoryResponse : IMapFrom<DriverLicenseCategory>
    {
        public Guid Identifier { get; set; }
        public string Category { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DriverLicenseCategory, DriverLicenseCategoryResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category));
        }
    }
}
