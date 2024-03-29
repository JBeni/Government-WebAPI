﻿namespace GovernmentSystem.Infrastructure.Services
{
    public class PublicServantSeriousFraudOfficeService : IPublicServantSeriousFraudOfficeservice
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public PublicServantSeriousFraudOfficeService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreatePublicServantSeriousFraudOffice(CreatePublicServantSeriousFraudOfficeCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantSeriousFraudOffices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of serious fraud office already exists");
            }
            var seriousFraudOffice = _insideEntityService.GetSeriousFraudOfficeById(command.SeriousFraudOfficeId);
            var entity = new PublicServantSeriousFraudOffice
            {
                SeriousFraudOffice = seriousFraudOffice.Item,
                CNP = command.CNP,
                ContractYears = command.ContractYears,
                DutyRole = command.DutyRole,
                FirstName = command.FirstName,
                HireEndDate = command.HireEndDate,
                HireStartDate = command.HireStartDate,
                LastName = command.LastName
            };

            _dbContext.PublicServantSeriousFraudOffices.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeletePublicServantSeriousFraudOffice(DeletePublicServantSeriousFraudOfficeCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantSeriousFraudOffices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of serious fraud office does not exists");
            }

            _dbContext.PublicServantSeriousFraudOffices.Remove(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(publicServant.Identifier);
        }

        public Result<PublicServantSeriousFraudOfficeResponse> GetPublicServantSeriousFraudOfficeById(GetPublicServantSeriousFraudOfficeByIdQuery query)
        {
            var result = _dbContext.PublicServantSeriousFraudOffices
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PublicServantSeriousFraudOfficeResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<PublicServantSeriousFraudOfficeResponse> { Successful = true, Item = result ?? new PublicServantSeriousFraudOfficeResponse() };
        }

        public Result<PublicServantSeriousFraudOfficeResponse> GetPublicServantSeriousFraudOffices(GetPublicServantSeriousFraudOfficesQuery query)
        {
            var result = _dbContext.PublicServantSeriousFraudOffices
                .ProjectTo<PublicServantSeriousFraudOfficeResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<PublicServantSeriousFraudOfficeResponse> { Successful = true, Items = result ?? new List<PublicServantSeriousFraudOfficeResponse>() };
        }

        public async Task<RequestResponse> UpdatePublicServantSeriousFraudOffice(UpdatePublicServantSeriousFraudOfficeCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantSeriousFraudOffices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of serious fraud office does not exists");
            }
            var seriousFraudOffice = _insideEntityService.GetSeriousFraudOfficeById(command.SeriousFraudOfficeId);

            publicServant.SeriousFraudOffice = seriousFraudOffice.Item;
            publicServant.CNP = command.CNP;
            publicServant.ContractYears = command.ContractYears;
            publicServant.DutyRole = command.DutyRole;
            publicServant.FirstName = command.FirstName;
            publicServant.HireEndDate = command.HireEndDate;
            publicServant.HireStartDate = command.HireStartDate;
            publicServant.LastName = command.LastName;

            _dbContext.PublicServantSeriousFraudOffices.Update(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(publicServant.Identifier);

        }
    }
}
