﻿using GovernmentSystem.Application.Handlers.DriverLicenseCategories.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IDriverLicenseCategoryService
    {
        DriverLicenseCategoryResponse GetDriverLicenseCategoryById(GetDriverLicenseCategoryByIdQuery query);
        List<DriverLicenseCategoryResponse> GetDriverLicenseCategories(GetDriverLicenseCategoriesQuery query);
    }
}