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
        public int Id { get; set; }
        public string CNP { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
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
            RuleFor(v => v.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
