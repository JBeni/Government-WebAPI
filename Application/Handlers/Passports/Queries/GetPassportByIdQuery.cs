namespace GovernmentSystem.Application.Handlers.Passports.Queries
{
    public class GetPassportByIdQuery : IRequest<Result<PassportResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPassportByIdQueryHandler : IRequestHandler<GetPassportByIdQuery, Result<PassportResponse>>
    {
        private readonly IPassportService _passportService;

        public GetPassportByIdQueryHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public Task<Result<PassportResponse>> Handle(GetPassportByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _passportService.GetPassportById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PassportResponse>
                {
                    Error = $"There was an error retrieving the passport by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
