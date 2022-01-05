namespace GovernmentSystem.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDriverLicenseCategoryAsync(ApplicationDbContext context)
        {
            if (!context.DriverLicenseCategories.Any())
            {
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "None" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "Am" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "A1" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "A2" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "A" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "B1" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "B" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "C1" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "C" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "D1" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "D" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "BE" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "C1E" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "CE" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "D1E" });
                context.DriverLicenseCategories.Add(new DriverLicenseCategory { Category = "DE" });
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Citizens.Any())
            {
                context.Citizens.Add(
                    new Citizen
                    {
                        FirstName = "Beni",
                        LastName = "LastName",
                        CNP = "123903829833",
                        Age = 21,
                        DateOfBirth = new DateTime(1990, 9, 25)
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
