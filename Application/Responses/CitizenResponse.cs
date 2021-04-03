using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class CitizenResponse : IMapFrom<Citizen>
    {
        public Guid Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNP { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public BirthCertificate BirthCertificate { get; set; }
        public IdentityCard IdentityCard { get; set; }
        public Passport Passport { get; set; }
        public DriverLicense DriverLicense { get; set; }
        public Address HomeAddress { get; set; }
        public CityHall CityHallResidence { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public PublicServantMedicalCenter PublicServantMedicalCenter { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Citizen, CitizenResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.CNP, opt => opt.MapFrom(s => s.CNP))
                .ForMember(d => d.Age, opt => opt.MapFrom(s => s.Age))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.Gender))
                .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(s => s.DateOfBirth))
                .ForMember(d => d.DateOfDeath, opt => opt.MapFrom(s => s.DateOfDeath))
                .ForMember(d => d.BirthCertificate, opt => opt.MapFrom(s => s.BirthCertificate))
                .ForMember(d => d.IdentityCard, opt => opt.MapFrom(s => s.IdentityCard))
                .ForMember(d => d.Passport, opt => opt.MapFrom(s => s.Passport))
                .ForMember(d => d.DriverLicense, opt => opt.MapFrom(s => s.DriverLicense))
                .ForMember(d => d.HomeAddress, opt => opt.MapFrom(s => s.HomeAddress))
                .ForMember(d => d.CityHallResidence, opt => opt.MapFrom(s => s.CityHallResidence))
                .ForMember(d => d.MedicalCenter, opt => opt.MapFrom(s => s.MedicalCenter))
                .ForMember(d => d.PublicServantMedicalCenter, opt => opt.MapFrom(s => s.PublicServantMedicalCenter));
        }
    }
}
