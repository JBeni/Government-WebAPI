﻿namespace GovernmentSystem.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public CompanyService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateCompany(CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            var company = _dbContext.Companies.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (company != null)
            {
                throw new Exception("The company already exists");
            }
            var officeAddress = _insideEntityService.GetAddressById(command.OfficeAddressId);
            var founder = _insideEntityService.GetCitizenById(command.FounderId);

            var entity = new Company
            {
                CIF = command.CIF,
                Name = command.Name,
                FoundationYear = command.FoundationYear,
                Domain = command.Domain,
                Description = command.Description,
                Status = command.Status,
                DeletionDate = command.DeletionDate,
                Founder = founder.Item,
                OfficeAddress = officeAddress.Item
            };

            _dbContext.Companies.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteCompany(DeleteCompanyCommand command, CancellationToken cancellationToken)
        {
            var company = _dbContext.Companies.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (company == null)
            {
                throw new Exception("The company does not exists");
            }

            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(company.Identifier);
        }

        public Result<CompanyResponse> GetCompanyById(GetCompanyByIdQuery query)
        {
            var result = _dbContext.Companies
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<CompanyResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<CompanyResponse> { Successful = true, Item = result ?? new CompanyResponse() };
        }

        public Result<CompanyResponse> GetCompanies(GetCompaniesQuery query)
        {
            var result = _dbContext.Companies
                .ProjectTo<CompanyResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<CompanyResponse> { Successful = true, Items = result ?? new List<CompanyResponse>() };
        }

        public async Task<RequestResponse> UpdateCompany(UpdateCompanyCommand command, CancellationToken cancellationToken)
        {
            var company = _dbContext.Companies.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (company == null)
            {
                throw new Exception("The company does not exists");
            }
            var officeAddress = _insideEntityService.GetAddressById(command.OfficeAddressId);
            var founder = _insideEntityService.GetCitizenById(command.FounderId);

            company.CIF = command.CIF;
            company.Name = command.Name;
            company.FoundationYear = command.FoundationYear;
            company.Domain = command.Domain;
            company.Description = command.Description;
            company.Status = command.Status;
            company.DeletionDate = command.DeletionDate;
            company.Founder = founder.Item;
            company.OfficeAddress = officeAddress.Item;

            _dbContext.Companies.Update(company);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(company.Identifier);
        }
    }
}
