using Microsoft.EntityFrameworkCore;
using Repositories.Concrete.Context;

namespace Store.Infrastructe.Extensions
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

        public static void ConfigureLocalization(this WebApplication webApplication)  //bir önceki methodu IApplicationBuilder üzerinden genişlettik bunu da Web app üzerinden genişletice<.
        {
            //bu bir middleware dir ve kültür bilgilerini set etmeye yarar
            webApplication.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("en-EN") //kültür desteğini ekleriz.
                    .AddSupportedCultures("en-EN")
                    .SetDefaultCulture("en-EN");
            }); 
        }
    }
}
