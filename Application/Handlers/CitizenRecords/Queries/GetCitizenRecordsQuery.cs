namespace GovernmentSystem.Application.Handlers.CitizenRecords.Queries
{
    public class GetCitizenRecordsQuery : IRequest<Result<CitizenRecordResponse>>
    {
    }

    public class GetCitizenRecordsQueryHandler : IRequestHandler<GetCitizenRecordsQuery, Result<CitizenRecordResponse>>
    {
        private readonly ICitizenRecordService _citizenRecordService;

        public GetCitizenRecordsQueryHandler(ICitizenRecordService citizenRecordService)
        {
            _citizenRecordService = citizenRecordService;
        }

        public Task<Result<CitizenRecordResponse>> Handle(GetCitizenRecordsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenRecordService.GetCitizenRecords(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CitizenRecordResponse>
                {
                    Error = $"There was an error retrieving the citizen records. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
