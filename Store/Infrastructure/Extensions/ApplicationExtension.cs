using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Concrete.Context;

namespace Store.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigrations(this IApplicationBuilder application)
        {
            RepositoryContext context = application
                .ApplicationServices 
                .CreateScope()
                .ServiceProvider 
                .GetRequiredService<RepositoryContext>();  

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        public static void ConfigureLocalization(this WebApplication webApplication) 
        {
            webApplication.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("en-EN") 
                    .AddSupportedCultures("en-EN")
                    .SetDefaultCulture("en-EN");
            }); 
        }
        
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123";
            
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider 
                .GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>(); 

            IdentityUser user = await userManager.FindByNameAsync(adminUser); 

            if (user == null)
            {
                user = new IdentityUser()
                {
                    Email = "sercanislii@gmail.com",
                    PhoneNumber = "5365177035",
                    UserName = adminUser
                };
                
                var result= await userManager.CreateAsync(user, adminPassword);
                
                if (!result.Succeeded)
                {
                    throw new Exception("Admin user could not created");
                }

                var roleResult = await userManager.AddToRolesAsync(user,
                    roleManager 
                        .Roles
                        .Select(r=>r.Name)
                        .ToList()
                );
                
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System have problems with role defination for admin");
                }
            }
        }
    }
}
