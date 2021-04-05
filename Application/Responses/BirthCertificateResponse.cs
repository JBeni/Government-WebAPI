using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.Citizens;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class BirthCertificateResponse : IMapFrom<BirthCertificate>
    {
        public Guid Identifier { get; set; }
        public string PersonalIdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Country { get; set; }
        public string Series { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
        public string RegistrationPlace { get; set; }
        public DateTime RegistrationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BirthCertificate, BirthCertificateResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.PersonalIdentificationNumber, opt => opt.MapFrom(s => s.PersonalIdentificationNumber))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => s.BirthDate))
                .ForMember(d => d.BirthPlace, opt => opt.MapFrom(s => s.BirthPlace))
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Country))
                .ForMember(d => d.Series, opt => opt.MapFrom(s => s.Series))
                .ForMember(d => d.Mother, opt => opt.MapFrom(s => s.Mother))
                .ForMember(d => d.Father, opt => opt.MapFrom(s => s.Father))
                .ForMember(d => d.RegistrationPlace, opt => opt.MapFrom(s => s.RegistrationPlace))
                .ForMember(d => d.RegistrationDate, opt => opt.MapFrom(s => s.RegistrationDate));
        }
    }
}
