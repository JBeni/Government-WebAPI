namespace GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Queries
{
    public class GetCitizenMedicalHistoriesQuery : IRequest<List<CitizenMedicalHistoryResponse>>
    {
    }

    public class GetCitizenMedicalHistoriesQueryHandler : IRequestHandler<GetCitizenMedicalHistoriesQuery, List<CitizenMedicalHistoryResponse>>
    {
        private readonly ICitizenMedicalHistoryService _citizenMedicalHistoryService;

        public GetCitizenMedicalHistoriesQueryHandler(ICitizenMedicalHistoryService citizenMedicalHistoryService)
        {
            _citizenMedicalHistoryService = citizenMedicalHistoryService;
        }

        public Task<List<CitizenMedicalHistoryResponse>> Handle(GetCitizenMedicalHistoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenMedicalHistoryService.GetCitizenMedicalHistories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the citizen medical histories", ex);
            }
        }
    }
}
