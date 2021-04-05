using GovernmentSystem.Domain.Entities.Citizens;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        //public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        //{
        //    var administratorRole = new ApplicationRole
        //    {
        //        Name = "Administrator"
        //    };

        //    if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        //    {
        //        await roleManager.CreateAsync(administratorRole);
        //    }

        //    var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        //    if (userManager.Users.All(u => u.UserName != administrator.UserName))
        //    {
        //        await userManager.CreateAsync(administrator, "Administrator1!");
        //        await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        //    }
        //}

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
                        LastName = "Jitca",
                        CNP = "1933423129812",
                        Age = 21,
                        DateOfBirth = new DateTime(1990, 9, 25)
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
