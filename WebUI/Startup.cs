using FluentValidation.AspNetCore;
using GovernmentSystem.Application;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Infrastructure;
using GovernmentSystem.Infrastructure.Persistence;
using GovernmentSystem.WebUI.Filters;
using GovernmentSystem.WebUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GovernmentSystem.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddInfrastructureLayer(Configuration);

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

            services.AddControllers(options =>
                options.Filters.Add<ApiExceptionFilterAttribute>()).AddFluentValidation();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new HeaderApiVersionReader("API-Version");

                //options.Conventions.Controller<CitizensController>()
                //    .HasApiVersion(1, 0)
                //    .Action(f => f.GetCitizensWithPagination(new GetCitizensWithPaginationQuery())).MapToApiVersion(1, 0);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebUI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebUI v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
