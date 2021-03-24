﻿using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CitizenEntities;

namespace GovernmentSystem.Application.Responses
{
    public class CitizenResponse : IMapFrom<Citizen>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Citizen, CitizenResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
