namespace GovernmentSystem.Application.Interfaces
{
    public interface IRegularizationService
    {
        Task<RequestResponse> CreateRegularization(CreateRegularizationCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteRegularization(DeleteRegularizationCommand command, CancellationToken cancellationToken);
        Result<RegularizationResponse> GetRegularizationById(GetRegularizationByIdQuery query);
        Result<RegularizationResponse> GetRegularizations(GetRegularizationsQuery query);
        Task<RequestResponse> UpdateRegularization(UpdateRegularizationCommand command, CancellationToken cancellationToken);
    }
}
