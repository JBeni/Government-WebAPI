try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("EnableCORS", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

    builder.Services.AddApplicationLayer();
    builder.Services.AddInfrastructureLayer(builder.Configuration);

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

    builder.Services.AddHttpContextAccessor();
    builder.Services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

    builder.Services.AddControllers(options =>
        options.Filters.Add<ApiExceptionFilterAttribute>()).AddFluentValidation();

    // Customise default API behaviour
    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    builder.Services.AddApiVersioning(options =>
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

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v2", new OpenApiInfo { Title = "WebUI", Version = "v2" });
    });


    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }

            //await ApplicationDbContextSeed.SeedSampleDataAsync(context);
            //await ApplicationDbContextSeed.SeedSampleDriverLicenseCategoryAsync(context);
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            Log.Logger.Error(ex, "An error occurred while migrating or seeding the database.");
            throw;
        }
    }


    if (app.Environment.IsDevelopment())
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

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message.ToString());
}
finally
{
    Console.WriteLine("Application was completed shut down");
}
