﻿using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalCenters.Queries
{
    public class GetMedicalCentersQuery : IRequest<List<MedicalCentersResponse>>
    {
        public string County { get; set; }
    }

    public class GetMedicalCentersQueryHandler : IRequestHandler<GetMedicalCentersQuery, List<MedicalCentersResponse>>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public GetMedicalCentersQueryHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public Task<List<MedicalCentersResponse>> Handle(GetMedicalCentersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterService.GetMedicalCenters(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class MedicalCentersResponse : IMapFrom<MedicalCenter>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<MedicalCenter, MedicalCentersResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
