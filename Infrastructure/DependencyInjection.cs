using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Infrastructure.Files;
using GovernmentSystem.Infrastructure.Persistence;
using GovernmentSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GovernmentSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("GovernmentSystemDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddAuthorization(options =>
            {
                // Example of policy
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddTransient<ICitizenService, CitizenService>();
            services.AddTransient<IMedicalCenterService, MedicalCenterService>();
            services.AddTransient<ICityHallService, CityHallService>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<ICitizenRequestService, CitizenRequestService>();
            services.AddTransient<IReportProblemService, ReportProblemService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<ICitizenMedicalHistoryService, CitizenMedicalHistoryService>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            services.AddTransient<IUploadDocument, UploadDocument>();

            return services;
        }
    }
}
