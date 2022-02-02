namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Queries
{
    public class GetMedicalProcedureByIdQuery : IRequest<Result<MedicalProcedureResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetMedicalProcedureByIdQueryHandler : IRequestHandler<GetMedicalProcedureByIdQuery, Result<MedicalProcedureResponse>>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public GetMedicalProcedureByIdQueryHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public Task<Result<MedicalProcedureResponse>> Handle(GetMedicalProcedureByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalProcedureservice.GetMedicalProcedureById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<MedicalProcedureResponse>
                {
                    Error = $"There was an error retrieving the medical procedure by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
