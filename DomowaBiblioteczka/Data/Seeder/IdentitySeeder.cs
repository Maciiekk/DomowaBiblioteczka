using Microsoft.AspNetCore.Identity;

namespace DomowaBiblioteczka.Data.Seeder
{
    public static class IdentitySeeder
    {
        public static async Task Seed(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await SeedRoles(roleManager);

            await SeedUser(userManager);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }           

        }

        private static async Task SeedUser(UserManager<ApplicationUser> userManager)
        {
            if (userManager.Users.Count() == 0)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@admin.admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.ADMIN.COM",
                    Email = "admin@admin.admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.ADMIN.COM",
                    EmailConfirmed = true,
                };

                var normalUser = new ApplicationUser
                {
                    UserName = "adam.abacki@email.pl",
                    NormalizedUserName = "ADAM.ABACKI@EMAIL.PL",
                    Email = "adam.abacki@email.pl",
                    NormalizedEmail = "ADAM.ABACKI@EMAIL.PL",
                    EmailConfirmed = true,
                };

                await userManager.CreateAsync(adminUser, "zxcV1234!");
                await userManager.CreateAsync(normalUser, "zxcV1234!");

                await AssignRoles(userManager, adminUser.Email,["Admin"]);
                await AssignRoles(userManager, normalUser.Email,["User"]);
            }

        }

        private static async Task<IdentityResult> AssignRoles(UserManager<ApplicationUser> userManager, string email, string[] roles)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);

            if (user != null) 
            {
                var result = await userManager.AddToRolesAsync(user, roles);
                
                return result; 
            }
            else
            {
                Console.WriteLine("User Seed Error: Role can not be assinged.");
            }

            return null;
        }
    }
}