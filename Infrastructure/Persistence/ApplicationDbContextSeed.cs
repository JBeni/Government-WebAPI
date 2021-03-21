using GovernmentSystem.Domain.Entities.CitizenEntities;
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
                        //Passport = "sdfsdfs",
                        //CI = "dsfsdf",
                        Age = 21,
                        DateOfBirth = new DateTime(1990, 9, 25)
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
