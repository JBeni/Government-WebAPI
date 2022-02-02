namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Queries
{
    public class GetMedicalCenterProcedureByIdQuery : IRequest<Result<MedicalCenterProcedureResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetMedicalCenterProcedureByIdQueryHandler : IRequestHandler<GetMedicalCenterProcedureByIdQuery, Result<MedicalCenterProcedureResponse>>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public GetMedicalCenterProcedureByIdQueryHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public Task<Result<MedicalCenterProcedureResponse>> Handle(GetMedicalCenterProcedureByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterProcedureService.GetMedicalCenterProcedureById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<MedicalCenterProcedureResponse>
                {
                    Error = $"There was an error retrieving the medical center procedure by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
