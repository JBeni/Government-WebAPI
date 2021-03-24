using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.BirthCertificates.Commands;
using GovernmentSystem.Application.Handlers.BirthCertificates.Queries;
using GovernmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class BirthCertificateService : IBirthCertificateService
    {
        private readonly IApplicationDbContext _dbContext;

        public BirthCertificateService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<RequestResponse> CreateBirthCertificate(CreateBirthCertificateCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeleteBirthCertificate(DeleteBirthCertificateCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public BirthCertificateByIdResponse GetBirthCertificateById(GetBirthCertificateByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<BirthCertificateResponse> GetBirthCertificates(GetBirthCertificatesQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdateBirthCertificate(UpdateBirthCertificateCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
