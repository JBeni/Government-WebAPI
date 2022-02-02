namespace GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Queries
{
    public class GetCitizenMedicalHistoriesQuery : IRequest<Result<CitizenMedicalHistoryResponse>>
    {
    }

    public class GetCitizenMedicalHistoriesQueryHandler : IRequestHandler<GetCitizenMedicalHistoriesQuery, Result<CitizenMedicalHistoryResponse>>
    {
        private readonly ICitizenMedicalHistoryService _citizenMedicalHistoryService;

        public GetCitizenMedicalHistoriesQueryHandler(ICitizenMedicalHistoryService citizenMedicalHistoryService)
        {
            _citizenMedicalHistoryService = citizenMedicalHistoryService;
        }

        public Task<Result<CitizenMedicalHistoryResponse>> Handle(GetCitizenMedicalHistoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenMedicalHistoryService.GetCitizenMedicalHistories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CitizenMedicalHistoryResponse>
                {
                    Error = $"There was an error retrieving the citizen medical histories. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
