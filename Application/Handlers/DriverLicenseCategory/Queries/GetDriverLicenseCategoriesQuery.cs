using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.DriverLicenseCategory.Queries
{
    public class GetDriverLicenseCategoriesQuery : IRequest<List<DriverLicenseCategoryResponse>>
    {
    }

    public class GetDriverLicenseCategoriesQueryHandler : IRequestHandler<GetDriverLicenseCategoriesQuery, List<DriverLicenseCategoryResponse>>
    {
        private readonly IDriverLicenseCategoryService _driverLicenseCategoryService;

        public GetDriverLicenseCategoriesQueryHandler(IDriverLicenseCategoryService driverLicenseCategoryService)
        {
            _driverLicenseCategoryService = driverLicenseCategoryService;
        }

        public Task<List<DriverLicenseCategoryResponse>> Handle(GetDriverLicenseCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _driverLicenseCategoryService.GetDriverLicenseCategories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the driver license categories", ex);
            }
        }
    }
}
