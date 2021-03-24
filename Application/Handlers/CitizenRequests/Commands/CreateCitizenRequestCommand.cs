using FluentValidation;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CitizenRequests.Commands
{
    public class CreateCitizenRequestCommand : IRequest<RequestResponse>
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

    public class CreateCitizemRequestCommandHandler : IRequestHandler<CreateCitizenRequestCommand,RequestResponse>
    {
        private readonly ICitizenRequestService _citizenRequestService;

        public CreateCitizemRequestCommandHandler(ICitizenRequestService citizenRequestService)
        {
            _citizenRequestService = citizenRequestService;
        }

        public async Task<RequestResponse> Handle(CreateCitizenRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenRequestService.CreateCitizenRequest(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateCitizenRequestCommandValidator : AbstractValidator<CreateCitizenRequestCommand>
    {
        public CreateCitizenRequestCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
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
