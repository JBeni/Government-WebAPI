﻿namespace GovernmentSystem.Application.Handlers.DriverLicenseCategories.Queries
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
