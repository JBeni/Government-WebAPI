namespace GovernmentSystem.Application.Handlers.BirthCertificates.Queries
{
    public class GetBirthCertificatesQuery : IRequest<Result<BirthCertificateResponse>>
    {
    }

    public class GetBirthCertificatesQueryHandler : IRequestHandler<GetBirthCertificatesQuery, Result<BirthCertificateResponse>>
    {
        private readonly IBirthCertificateService _birthCertificateService;

        public GetBirthCertificatesQueryHandler(IBirthCertificateService birthCertificateService)
        {
            _birthCertificateService = birthCertificateService;
        }

        public Task<Result<BirthCertificateResponse>> Handle(GetBirthCertificatesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _birthCertificateService.GetBirthCertificates(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<BirthCertificateResponse>
                {
                    Error = $"There was an error retrieving the birth certificates. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
