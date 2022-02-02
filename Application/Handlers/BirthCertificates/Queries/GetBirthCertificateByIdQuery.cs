namespace GovernmentSystem.Application.Handlers.BirthCertificates.Queries
{
    public class GetBirthCertificateByIdQuery : IRequest<Result<BirthCertificateResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetBirthCertificateByIdQueryHandler : IRequestHandler<GetBirthCertificateByIdQuery, Result<BirthCertificateResponse>>
    {
        private readonly IBirthCertificateService _birthCertificateService;

        public GetBirthCertificateByIdQueryHandler(IBirthCertificateService birthCertificateService)
        {
            _birthCertificateService = birthCertificateService;
        }

        public Task<Result<BirthCertificateResponse>> Handle(GetBirthCertificateByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _birthCertificateService.GetBirthCertificateById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<BirthCertificateResponse>
                {
                    Error = $"There was an error retrieving the birth certificate by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
