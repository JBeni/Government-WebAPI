namespace GovernmentSystem.Application.Interfaces
{
    public interface IDriverLicenseCategoryService
    {
        Result<DriverLicenseCategoryResponse> GetDriverLicenseCategoryById(GetDriverLicenseCategoryByIdQuery query);
        Result<DriverLicenseCategoryResponse> GetDriverLicenseCategories(GetDriverLicenseCategoriesQuery query);
    }
}
