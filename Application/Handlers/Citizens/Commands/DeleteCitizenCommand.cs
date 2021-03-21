using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Citizens.Commands
{
    public class DeleteCitizenCommand : IRequest<RequestResponse>
    {
        public string CNP { get; set; }
        public DateTime DateOfDeath { get; set; }
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
                return RequestResponse.Failure(ex);
            }
        }
    }
}
