namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenDriverLicenseCategoryService
    {
        Task<RequestResponse> CreateCitizenDriverLicenseCategory(CreateCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenDriverLicenseCategory(DeleteCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken);
        Result<CitizenDriverLicenseCategoryResponse> GetCitizenDriverLicenseCategoryById(GetCitizenDriverLicenseCategoryByIdQuery query);
        Result<CitizenDriverLicenseCategoryResponse> GetCitizenDriverLicenseCategories(GetCitizenDriverLicenseCategoriesQuery query);
        Task<RequestResponse> UpdateCitizenDriverLicenseCategory(UpdateCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken);
    }
}
