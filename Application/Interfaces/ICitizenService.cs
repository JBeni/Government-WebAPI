namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenService
    {
        Task<RequestResponse> CreateCitizen(CreateCitizenCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizen(DeleteCitizenCommand command, CancellationToken cancellationToken);
        string GenerateCNP(DateTime dateOfBirth, string userGender);
        Task<ExportCitizensVm> ExportCitizensQuery(ExportCitizensQuery query);
        Result<CitizenResponse> GetCitizenById(GetCitizenByIdQuery query);
        Result<CitizenResponse> GetCitizens(GetCitizensQuery query);
        Task<RequestResponse> UpdateCitizen(UpdateCitizenCommand command, CancellationToken cancellationToken);
    }
}
