﻿namespace GovernmentSystem.Application.Handlers.Citizens.Commands
{
    public class DeleteCitizenCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteCitizenCommandHandler : IRequestHandler<DeleteCitizenCommand, RequestResponse>
    {
        private readonly ICitizenService _citizenService;

        public DeleteCitizenCommandHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public async Task<RequestResponse> Handle(DeleteCitizenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenService.DeleteCitizen(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteCitizenCommandValidator : AbstractValidator<DeleteCitizenCommand>
    {
        public DeleteCitizenCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
