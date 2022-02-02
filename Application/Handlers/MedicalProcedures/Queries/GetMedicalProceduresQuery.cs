namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Queries
{
    public class GetMedicalProceduresQuery : IRequest<Result<MedicalProcedureResponse>>
    {
    }

    public class GetMedicalProceduresQueryHandler : IRequestHandler<GetMedicalProceduresQuery, Result<MedicalProcedureResponse>>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public GetMedicalProceduresQueryHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public Task<Result<MedicalProcedureResponse>> Handle(GetMedicalProceduresQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalProcedureservice.GetMedicalProcedures(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<MedicalProcedureResponse>
                {
                    Error = $"There was an error retrieving the medical procedures. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
