namespace GovernmentSystem.Application.Interfaces
{
    public interface IDriverLicenseCategoryService
    {
        DriverLicenseCategoryResponse GetDriverLicenseCategoryById(GetDriverLicenseCategoryByIdQuery query);
        List<DriverLicenseCategoryResponse> GetDriverLicenseCategories(GetDriverLicenseCategoriesQuery query);
    }
}
