using GovernmentSystem.Application.BusinessLogic.Interfaces;
using GovernmentSystem.Application.Common.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.BusinessLogic.Handlers.Citizens.Commands
{
    public class DeleteCitizenCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
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
                var result = await _citizenService.DeleteCitizen(request, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }
}
