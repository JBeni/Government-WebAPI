namespace GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Commands
{
    public class DeletePublicServantMedicalCenterCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePublicServantMedicalCentersCommandHandler : IRequestHandler<DeletePublicServantMedicalCenterCommand, RequestResponse>
    {
        private readonly IPublicServantMedicalCenterService _publicServantMedicalCenterService;

        public DeletePublicServantMedicalCentersCommandHandler(IPublicServantMedicalCenterService publicServantMedicalCenterService)
        {
            _publicServantMedicalCenterService = publicServantMedicalCenterService;
        }

        public async Task<RequestResponse> Handle(DeletePublicServantMedicalCenterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantMedicalCenterService.DeletePublicServantMedicalCenter(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeletePublicServantMedicalCenterCommandValidator : AbstractValidator<DeletePublicServantMedicalCenterCommand>
    {
        public DeletePublicServantMedicalCenterCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
