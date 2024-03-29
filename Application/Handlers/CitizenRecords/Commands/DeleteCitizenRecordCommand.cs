﻿namespace GovernmentSystem.Application.Handlers.CitizenRecords.Commands
{
    public class DeleteCitizenRecordCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteCitizenRecordCommandHandler : IRequestHandler<DeleteCitizenRecordCommand, RequestResponse>
    {
        private readonly ICitizenRecordService _citizenRecordService;

        public DeleteCitizenRecordCommandHandler(ICitizenRecordService citizenRecordService)
        {
            _citizenRecordService = citizenRecordService;
        }

        public async Task<RequestResponse> Handle(DeleteCitizenRecordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenRecordService.DeleteCitizenRecord(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteCitizenRecordCommandValidator : AbstractValidator<DeleteCitizenRecordCommand>
    {
        public DeleteCitizenRecordCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
