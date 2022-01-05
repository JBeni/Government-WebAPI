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
                CitizenWhoBenefit = citizenWhoBenefit,
                CitizenWhoPaid = citizenWhoPaid,
                Invoice = invoice,
                MedicalCenter = medicalCenter,
                MedicalProcedure = medicalProcedure,
                PublicServantMedicalCenter = publicServantMedicalCenter
            };

            _dbContext.MedicalPayments.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
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
            return RequestResponse.Success();
        }

        public List<MedicalPaymentResponse> GetMedicalPayments(GetMedicalPaymentsQuery query)
        {
            var result = _dbContext.MedicalPayments
                .ProjectTo<MedicalPaymentResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public MedicalPaymentResponse GetMedicalPaymentById(GetMedicalPaymentByIdQuery query)
        {
            var result = _dbContext.MedicalPayments
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalPaymentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
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
            medicalPayment.CitizenWhoBenefit = citizenWhoBenefit;
            medicalPayment.CitizenWhoPaid = citizenWhoPaid;
            medicalPayment.Invoice = invoice;
            medicalPayment.MedicalCenter = medicalCenter;
            medicalPayment.MedicalProcedure = medicalProcedure;
            medicalPayment.PublicServantMedicalCenter = publicServantMedicalCenter;

            _dbContext.MedicalPayments.Update(medicalPayment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
