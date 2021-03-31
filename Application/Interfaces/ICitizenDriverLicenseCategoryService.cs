using GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenDriverLicenseCategoryService
    {
        CitizenDriverLicenseCategoryResponse GetCitizenDriverLicenseCategoryById(GetCitizenDriverLicenseCategoryByIdQuery query);
        List<CitizenDriverLicenseCategoryResponse> GetCitizenDriverLicenseCategories(GetCitizenDriverLicenseCategoriesQuery query);
    }
}
