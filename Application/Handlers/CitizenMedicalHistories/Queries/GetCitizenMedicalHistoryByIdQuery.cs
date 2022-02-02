namespace GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Queries
{
    public class GetCitizenMedicalHistoryByIdQuery : IRequest<Result<CitizenMedicalHistoryResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCitizenMedicalHistoryQueryHandler : IRequestHandler<GetCitizenMedicalHistoryByIdQuery, Result<CitizenMedicalHistoryResponse>>
    {
        private readonly ICitizenMedicalHistoryService _citizenMedicalHistoryService;

        public GetCitizenMedicalHistoryQueryHandler(ICitizenMedicalHistoryService citizenMedicalHistoryService)
        {
            _citizenMedicalHistoryService = citizenMedicalHistoryService;
        }

        public Task<Result<CitizenMedicalHistoryResponse>> Handle(GetCitizenMedicalHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenMedicalHistoryService.GetCitizenMedicalHistoryById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CitizenMedicalHistoryResponse>
                {
                    Error = $"There was an error retrieving the citizen medical history by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
