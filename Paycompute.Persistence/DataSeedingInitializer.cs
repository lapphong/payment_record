using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paycompute.Persistence
{
    public static class DataSeedingInitializer
    {
        public static async Task UserAndRoleSeedAsync(UserManager<IdentityUser> userManager,
               RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Manager", "Staff" };
            foreach (var role in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create admin user
            if (userManager.FindByEmailAsync("stuart@positronicstudios.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "stuart@positronicstudios.com",
                    Email = "stuart@positronicstudios.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password14").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();

                }
            }

            // Create manager user
            if (userManager.FindByEmailAsync("manager@positronicstudios.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "manager@positronicstudios.com",
                    Email = "manager@positronicstudios.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password14").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();

                }
            }

            // Create staff user
            if (userManager.FindByEmailAsync("jane.doe@positronicstudios.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "jane.doe@positronicstudios.com",
                    Email = "jane.doe@positronicstudios.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password14").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Staff").Wait();

                }
            }

            // Create no role user
            if (userManager.FindByEmailAsync("jeff.deer@positronicstudios.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "jeff.deer@positronicstudios.com",
                    Email = "jeff.deer@positronicstudios.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password14").Result;
                // No role assigned to Jeff Deer
            }
        }
    }
}
