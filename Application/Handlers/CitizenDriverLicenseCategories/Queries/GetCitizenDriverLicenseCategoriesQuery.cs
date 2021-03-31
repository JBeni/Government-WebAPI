using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CitizenDriverLicenseCategories.Queries
{
    public class GetCitizenDriverLicenseCategoriesQuery : IRequest<List<CitizenDriverLicenseCategoryResponse>>
    {
    }

    public class GetCitizenDriverLicenseCategoriesQueryHandler : IRequestHandler<GetCitizenDriverLicenseCategoriesQuery, List<CitizenDriverLicenseCategoryResponse>>
    {
        private readonly ICitizenDriverLicenseCategoryService _citizenDriverLicenseCategoryService;

        public GetCitizenDriverLicenseCategoriesQueryHandler(ICitizenDriverLicenseCategoryService citizenDriverLicenseCategoryService)
        {
            _citizenDriverLicenseCategoryService = citizenDriverLicenseCategoryService;
        }

        public Task<List<CitizenDriverLicenseCategoryResponse>> Handle(GetCitizenDriverLicenseCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenDriverLicenseCategoryService.GetCitizenDriverLicenseCategories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the citizen driver license categories", ex);
            }
        }
    }
}
