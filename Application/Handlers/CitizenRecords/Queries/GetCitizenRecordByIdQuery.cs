namespace GovernmentSystem.Application.Handlers.CitizenRecords.Queries
{
    public class GetCitizenRecordByIdQuery : IRequest<Result<CitizenRecordResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCitizenRecordByIdQueryHandler : IRequestHandler<GetCitizenRecordByIdQuery, Result<CitizenRecordResponse>>
    {
        private readonly ICitizenRecordService _citizenRecordService;

        public GetCitizenRecordByIdQueryHandler(ICitizenRecordService citizenRecordService)
        {
            _citizenRecordService = citizenRecordService;
        }

        public Task<Result<CitizenRecordResponse>> Handle(GetCitizenRecordByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenRecordService.GetCitizenRecordById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CitizenRecordResponse>
                {
                    Error = $"There was an error retrieving the citizen record by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
