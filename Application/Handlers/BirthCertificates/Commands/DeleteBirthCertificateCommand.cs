namespace GovernmentSystem.Application.Handlers.BirthCertificates.Commands
{
    public class DeleteBirthCertificateCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteBirthCertificateCommandHandler : IRequestHandler<DeleteBirthCertificateCommand, RequestResponse>
    {
        private readonly IBirthCertificateService _birthCertificateService;

        public DeleteBirthCertificateCommandHandler(IBirthCertificateService birthCertificateService)
        {
            _birthCertificateService = birthCertificateService;
        }

        public async Task<RequestResponse> Handle(DeleteBirthCertificateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _birthCertificateService.DeleteBirthCertificate(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteBirthCertificateCommandValidator : AbstractValidator<DeleteBirthCertificateCommand>
    {
        public DeleteBirthCertificateCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
