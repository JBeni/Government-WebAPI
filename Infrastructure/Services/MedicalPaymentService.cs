namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalPaymentService : IMedicalPaymentService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public MedicalPaymentService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateMedicalPayment(CreateMedicalPaymentCommand command, CancellationToken cancellationToken)
        {
            var medicalPayment = _dbContext.MedicalPayments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalPayment != null)
            {
                throw new Exception("The medical payment already exists");
            }
            var citizenWhoBenefit = _insideEntityService.GetCitizenById(command.CitizenWhoBenefitId);
            var citizenWhoPaid = _insideEntityService.GetCitizenById(command.CitizenWhoPaidId);
            var invoice = _insideEntityService.GetInvoiceById(command.InvoiceId);
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var medicalProcedure = _insideEntityService.GetMedicalProcedureById(command.MedicalProcedureId);
            var publicServantMedicalCenter = _insideEntityService.GetPublicServantMedicalCenterById(command.PublicServantMedicalCenterId);

            var entity = new MedicalPayment
            {
                AmountPaid = command.AmountPaid,
                AmountToPay = command.AmountToPay,
                DateOfPayment = command.DateOfPayment,
                CitizenWhoBenefit = citizenWhoBenefit.Item,
                CitizenWhoPaid = citizenWhoPaid.Item,
                Invoice = invoice.Item,
                MedicalCenter = medicalCenter.Item,
                MedicalProcedure = medicalProcedure.Item,
                PublicServantMedicalCenter = publicServantMedicalCenter.Item
            };

            _dbContext.MedicalPayments.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteMedicalPayment(DeleteMedicalPaymentCommand command, CancellationToken cancellationToken)
        {
            var medicalPayment = _dbContext.MedicalPayments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalPayment != null)
            {
                throw new Exception("The medical payment does not exists");
            }

            _dbContext.MedicalPayments.Remove(medicalPayment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(medicalPayment.Identifier);
        }

        public Result<MedicalPaymentResponse> GetMedicalPayments(GetMedicalPaymentsQuery query)
        {
            var result = _dbContext.MedicalPayments
                .ProjectTo<MedicalPaymentResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<MedicalPaymentResponse> { Successful = true, Items = result ?? new List<MedicalPaymentResponse>() };
        }

        public Result<MedicalPaymentResponse> GetMedicalPaymentById(GetMedicalPaymentByIdQuery query)
        {
            var result = _dbContext.MedicalPayments
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalPaymentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<MedicalPaymentResponse> { Successful = true, Item = result ?? new MedicalPaymentResponse() };
        }

        public async Task<RequestResponse> UpdateMedicalPayment(UpdateMedicalPaymentCommand command, CancellationToken cancellationToken)
        {
            var medicalPayment = _dbContext.MedicalPayments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalPayment != null)
            {
                throw new Exception("The medical payment does not exists");
            }
            var citizenWhoBenefit = _insideEntityService.GetCitizenById(command.CitizenWhoBenefitId);
            var citizenWhoPaid = _insideEntityService.GetCitizenById(command.CitizenWhoPaidId);
            var invoice = _insideEntityService.GetInvoiceById(command.InvoiceId);
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var medicalProcedure = _insideEntityService.GetMedicalProcedureById(command.MedicalProcedureId);
            var publicServantMedicalCenter = _insideEntityService.GetPublicServantMedicalCenterById(command.PublicServantMedicalCenterId);

            medicalPayment.AmountPaid = command.AmountPaid;
            medicalPayment.AmountToPay = command.AmountToPay;
            medicalPayment.DateOfPayment = command.DateOfPayment;
            medicalPayment.CitizenWhoBenefit = citizenWhoBenefit.Item;
            medicalPayment.CitizenWhoPaid = citizenWhoPaid.Item;
            medicalPayment.Invoice = invoice.Item;
            medicalPayment.MedicalCenter = medicalCenter.Item;
            medicalPayment.MedicalProcedure = medicalProcedure.Item;
            medicalPayment.PublicServantMedicalCenter = publicServantMedicalCenter.Item;

            _dbContext.MedicalPayments.Update(medicalPayment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(medicalPayment.Identifier);
        }
    }
}
