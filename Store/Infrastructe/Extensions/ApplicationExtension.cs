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
    }
}
