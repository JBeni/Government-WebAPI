namespace GovernmentSystem.Application.Handlers.Passports.Queries
{
    public class GetPassportsQuery : IRequest<Result<PassportResponse>>
    {
    }

    public class GetPassportsQueryHandler : IRequestHandler<GetPassportsQuery, Result<PassportResponse>>
    {
        private readonly IPassportService _passportService;

        public GetPassportsQueryHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public Task<Result<PassportResponse>> Handle(GetPassportsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _passportService.GetPassports(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PassportResponse>
                {
                    Error = $"There was an error retrieving the passports. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
