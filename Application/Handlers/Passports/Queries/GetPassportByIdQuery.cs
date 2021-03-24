﻿using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Passports.Queries
{
    public class GetPassportByIdQuery : IRequest<PassportResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPassportByIdQueryHandler : IRequestHandler<GetPassportByIdQuery, PassportResponse>
    {
        private readonly IPassportService _passportService;

        public GetPassportByIdQueryHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public Task<PassportResponse> Handle(GetPassportByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _passportService.GetPassportById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
