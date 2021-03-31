using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class CitizenDriverLicenseCategoryResponse : IMapFrom<CitizenDriverLicenseCategory>
    {
        public Guid Identifier { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }

        public Citizen Citizen { get; set; }
        public DriverLicenseCategory DriverLicenseCategory { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CitizenDriverLicenseCategory, CitizenDriverLicenseCategoryResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.DateOfIssue, opt => opt.MapFrom(s => s.DateOfIssue))
                .ForMember(d => d.DateOfExpiry, opt => opt.MapFrom(s => s.DateOfExpiry));
        }
    }
}
