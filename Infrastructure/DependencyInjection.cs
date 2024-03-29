﻿namespace GovernmentSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddAuthorization(options =>
            {
                // Example of policy
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IAddressTypeService, AddressTypeService>();
            services.AddTransient<IBirthCertificateService, BirthCertificateService>();
            services.AddTransient<ICitizenDriverLicenseCategoryService, CitizenDriverLicenseCategoryService>();
            services.AddTransient<ICitizenMedicalHistoryService, CitizenMedicalHistoryService>();
            services.AddTransient<ICitizenRecordService, CitizenRecordService>();
            services.AddTransient<ICitizenRequestService, CitizenRequestService>();
            services.AddTransient<ICitizenService, CitizenService>();
            services.AddTransient<ITaxService, TaxService>();
            services.AddTransient<IPaymentHistoryService, PaymentHistoryService>();
            services.AddTransient<ICityHallService, CityHallService>();
            services.AddTransient<ICityPaymentService, CityPaymentService>();
            services.AddTransient<IDriverLicenseCategoryService, DriverLicenseCategoryService>();
            services.AddTransient<IDriverLicenseService, DriverLicenseService>();
            services.AddTransient<IIdentityCardAppointmentService, IdentityCardAppointmentService>();
            services.AddTransient<IIdentityCardService, IdentityCardService>();
            services.AddTransient<IInsideEntityService, InsideEntityService>();
            services.AddTransient<IMedicalAppointmentService, MedicalAppointmentService>();
            services.AddTransient<IMedicalCenterProcedureService, MedicalCenterProcedureService>();
            services.AddTransient<IMedicalCenterService, MedicalCenterService>();
            services.AddTransient<IMedicalPaymentService, MedicalPaymentService>();
            services.AddTransient<IMedicalProcedureService, MedicalProcedureService>();
            services.AddTransient<IRegularizationService, RegularizationService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IFraudOfficeReportProblemService, FraudOfficeReportProblemService>();
            services.AddTransient<IPassportService, PassportService>();
            services.AddTransient<IPoliceReportProblemService, PoliceReportProblemService>();
            services.AddTransient<IPolicePaymentService, PolicePaymentService>();
            services.AddTransient<IPoliceStationService, PoliceStationService>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<IPropertyTypeService, PropertyTypeService>();
            services.AddTransient<IPublicServantCityHallService, PublicServantCityHallService>();
            services.AddTransient<IPublicServantMedicalCenterService, PublicServantMedicalCenterService>();
            services.AddTransient<IPublicServantPoliceStationService, PublicServantPoliceStationService>();
            services.AddTransient<IPublicServantSeriousFraudOfficeservice, PublicServantSeriousFraudOfficeService>();
            services.AddTransient<ICityReportProblemService, CityReportProblemService>();
            services.AddTransient<ISeriousFraudOfficeService, SeriousFraudOfficeService>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            services.AddTransient<IUploadDocument, UploadDocument>();

            return services;
        }
    }
}
