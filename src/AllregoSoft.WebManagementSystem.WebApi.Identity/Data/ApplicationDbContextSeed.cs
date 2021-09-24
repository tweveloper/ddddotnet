using AllregoSoft.WebManagementSystem.WebApi.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.WebApi.Identity.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Admin");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            //var adminClaim = new Claim("Role", "Admin");

            var administrator = new ApplicationUser { Account = "admin", UserName = "admin", Email = "admin@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Pa$$w0rd");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
                //await userManager.AddClaimAsync(administrator, adminClaim);
            }
        }
    }
}
