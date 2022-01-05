namespace GovernmentSystem.Application.Handlers.MedicalProcedures.Queries
{
    public class GetMedicalProceduresQuery : IRequest<List<MedicalProcedureResponse>>
    {
    }

    public class GetMedicalProceduresQueryHandler : IRequestHandler<GetMedicalProceduresQuery, List<MedicalProcedureResponse>>
    {
        private readonly IMedicalProcedureService _medicalProcedureservice;

        public GetMedicalProceduresQueryHandler(IMedicalProcedureService medicalProcedureservice)
        {
            _medicalProcedureservice = medicalProcedureservice;
        }

        public Task<List<MedicalProcedureResponse>> Handle(GetMedicalProceduresQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalProcedureservice.GetMedicalProcedures(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the medical procedures", ex);
            }
        }
    }
}
