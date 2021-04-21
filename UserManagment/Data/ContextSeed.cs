using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagment.Models;

namespace UserManagment.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enum.Role.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enum.Role.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enum.Role.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enum.Role.Basic.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "SuperAdmin",
                Email = "superAdmin@banana.com",
                FirstName = "Zach",
                LastName = "Sperka",
                EmailConfirmed = true,
                PhoneNumberConfirmed =true
            };
            if(userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enum.Role.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enum.Role.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enum.Role.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enum.Role.SuperAdmin.ToString());
                }
            }

        }
    }
}
