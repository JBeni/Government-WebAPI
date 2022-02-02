namespace GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Queries
{
    public class GetMedicalCenterProceduresQuery : IRequest<Result<MedicalCenterProcedureResponse>>
    {
    }

    public class GetMedicalCenterProceduresQueryHandler : IRequestHandler<GetMedicalCenterProceduresQuery, Result<MedicalCenterProcedureResponse>>
    {
        private readonly IMedicalCenterProcedureService _medicalCenterProcedureService;

        public GetMedicalCenterProceduresQueryHandler(IMedicalCenterProcedureService medicalCenterProcedureService)
        {
            _medicalCenterProcedureService = medicalCenterProcedureService;
        }

        public Task<Result<MedicalCenterProcedureResponse>> Handle(GetMedicalCenterProceduresQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterProcedureService.GetMedicalCenterProcedures(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<MedicalCenterProcedureResponse>
                {
                    Error = $"There was an error retrieving the medical center procedures. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
