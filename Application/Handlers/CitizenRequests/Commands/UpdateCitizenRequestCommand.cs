﻿namespace GovernmentSystem.Application.Handlers.CitizenRequests.Commands
{
    public class UpdateCitizenRequestCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string UserCNP { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }

    public class UpdateCitizenRequestCommandHandler : IRequestHandler<UpdateCitizenRequestCommand, RequestResponse>
    {
        private readonly ICitizenRequestService _citizenRequestService;

        public UpdateCitizenRequestCommandHandler(ICitizenRequestService citizenRequestService)
        {
            _citizenRequestService = citizenRequestService;
        }

        public async Task<RequestResponse> Handle(UpdateCitizenRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenRequestService.UpdateCitizenRequest(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdateCitizenRequestCommandValidator : AbstractValidator<UpdateCitizenRequestCommand>
    {
        public UpdateCitizenRequestCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().Null();
            RuleFor(v => v.UserCNP).NotEmpty().NotNull();
            RuleFor(v => v.UserName).NotEmpty().NotNull();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.Type).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
            RuleFor(v => v.DateOfIssue).NotEmpty().NotNull();
            RuleFor(v => v.DateOfExpiry).NotEmpty().NotNull();
        }
    }
}
