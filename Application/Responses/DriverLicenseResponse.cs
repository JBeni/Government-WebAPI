﻿using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class DriverLicenseResponse : IMapFrom<DriverLicense>
    {
        public Guid Identifier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DriverLicense, DriverLicenseResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier));
        }
    }
}
