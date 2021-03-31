using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Commands;
using GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenDriverLicenseCategoryService
    {
        Task<RequestResponse> CreateCitizenDriverLicenseCategory(CreateCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenDriverLicenseCategory(DeleteCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken);
        CitizenDriverLicenseCategoryResponse GetCitizenDriverLicenseCategoryById(GetCitizenDriverLicenseCategoryByIdQuery query);
        List<CitizenDriverLicenseCategoryResponse> GetCitizenDriverLicenseCategories(GetCitizenDriverLicenseCategoriesQuery query);
        Task<RequestResponse> UpdateCitizenDriverLicenseCategory(UpdateCitizenDriverLicenseCategoryCommand command, CancellationToken cancellationToken);
    }
}
