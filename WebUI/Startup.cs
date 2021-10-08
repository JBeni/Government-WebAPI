using FluentValidation.AspNetCore;
using GovernmentSystem.Application;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Handlers.Addresses.Queries;
using GovernmentSystem.Infrastructure;
using GovernmentSystem.Infrastructure.Persistence;
using GovernmentSystem.WebUI.Controllers;
using GovernmentSystem.WebUI.Filters;
using GovernmentSystem.WebUI.Model;
using GovernmentSystem.WebUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Stripe;

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
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddApplicationLayer();
            services.AddInfrastructureLayer(Configuration);

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

            services.AddControllers(options =>
                options.Filters.Add<ApiExceptionFilterAttribute>()).AddFluentValidation();

            // Configure Stripe Payment Gateway
            StripeConfiguration.ApiKey = Configuration.GetSection("StripeKeys")["SecretKey"];
            services.Configure<StripeSettings>(Configuration.GetSection("StripeKeys"));

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(2, 0);
                options.ReportApiVersions = true;

                options.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader("x-api-version"),
                    new MediaTypeApiVersionReader("x-api-version")
                );

                // ensure that only request with x-api-version=1 could access the methods of the controller
                // MapToApiVersion("2.0") -> ensure the same behaviour but at method level
                options.Conventions.Controller<AddressesController>()
                    .HasApiVersion(2, 0);
                options.Conventions.Controller<AddressTypesController>()
                    .HasApiVersion(2, 0);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "WebUI", Version = "v2" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "WebUI v2"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors("EnableCORS");
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
