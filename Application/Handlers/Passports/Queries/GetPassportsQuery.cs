namespace GovernmentSystem.Application.Handlers.Passports.Queries
{
    public class GetPassportsQuery : IRequest<List<PassportResponse>>
    {
    }

    public class GetPassportsQueryHandler : IRequestHandler<GetPassportsQuery, List<PassportResponse>>
    {
        private readonly IPassportService _passportService;

        public GetPassportsQueryHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public Task<List<PassportResponse>> Handle(GetPassportsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _passportService.GetPassports(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the passports", ex);
            }
        }
    }
}
