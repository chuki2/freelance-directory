using Microsoft.AspNetCore.Identity;
using FreelancerDirectoryAPI.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace FreelancerDirectoryAPI.Domain.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var defaultUser = new ApplicationUser { UserName = "user@etiqa.com", Email = "user@etiqa.com" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Test@123");
                await userManager.AddToRolesAsync(defaultUser, new[] { administratorRole.Name });
            }
        }

    }
}
