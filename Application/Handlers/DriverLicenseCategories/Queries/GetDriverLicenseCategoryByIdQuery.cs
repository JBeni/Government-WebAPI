﻿namespace GovernmentSystem.Application.Handlers.DriverLicenseCategories.Queries
{
    public class GetDriverLicenseCategoryByIdQuery : IRequest<Result<DriverLicenseCategoryResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetDriverLicenseCategoryByIdQueryHandler : IRequestHandler<GetDriverLicenseCategoryByIdQuery, Result<DriverLicenseCategoryResponse>>
    {
        private readonly IDriverLicenseCategoryService _driverLicenseCategoryService;

        public GetDriverLicenseCategoryByIdQueryHandler(IDriverLicenseCategoryService driverLicenseCategoryService)
        {
            _driverLicenseCategoryService = driverLicenseCategoryService;
        }

        public Task<Result<DriverLicenseCategoryResponse>> Handle(GetDriverLicenseCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _driverLicenseCategoryService.GetDriverLicenseCategoryById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<DriverLicenseCategoryResponse>
                {
                    Error = $"There was an error retrieving the driver license category by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
