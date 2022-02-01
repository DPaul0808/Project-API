using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectApp.Models.Data
{
    internal class DbInitializer
    {
        internal static async Task Initialize(ProjectDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            context.Database.Migrate();

            if (context.Roles.Any())
            {
                return;
            }

            IdentityRole admin = new IdentityRole("High Tier Admin");
            IdentityRole role = new IdentityRole("User");
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "PaulD0808",
                Email = "pauldragomir87@gmail.com"
            };

            var resultAdmin = await roleManager.CreateAsync(admin);
            var resultRole = await roleManager.CreateAsync(role);
            var resultUser = await userManager.CreateAsync(user, "Qwerty!234"); //todo: to move to a more secure location
            var resultUserToRole = await userManager.AddToRoleAsync(user, admin.Name);

            context.Users.Add(user);
            context.SaveChanges();

        }
    }
}
