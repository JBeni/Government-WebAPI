namespace GovernmentSystem.Application.Handlers.CitizenRecords.Queries
{
    public class GetCitizenRecordsQuery : IRequest<List<CitizenRecordResponse>>
    {
    }

    public class GetCitizenRecordsQueryHandler : IRequestHandler<GetCitizenRecordsQuery, List<CitizenRecordResponse>>
    {
        private readonly ICitizenRecordService _citizenRecordService;

        public GetCitizenRecordsQueryHandler(ICitizenRecordService citizenRecordService)
        {
            _citizenRecordService = citizenRecordService;
        }

        public Task<List<CitizenRecordResponse>> Handle(GetCitizenRecordsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenRecordService.GetCitizenRecords(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the citizen records", ex);
            }
        }
    }
}
