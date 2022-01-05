namespace GovernmentSystem.Application.Handlers.CitizenRecords.Queries
{
    public class GetCitizenRecordByIdQuery : IRequest<CitizenRecordResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCitizenRecordByIdQueryHandler : IRequestHandler<GetCitizenRecordByIdQuery, CitizenRecordResponse>
    {
        private readonly ICitizenRecordService _citizenRecordService;

        public GetCitizenRecordByIdQueryHandler(ICitizenRecordService citizenRecordService)
        {
            _citizenRecordService = citizenRecordService;
        }

        public Task<CitizenRecordResponse> Handle(GetCitizenRecordByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenRecordService.GetCitizenRecordById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the citizen record by Id", ex);
            }
        }
    }
}
