using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ordering.API.Extensions
{
    public static class DBExtension
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder) 
            where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();
                try
                {
                    logger.LogInformation($"Started Db Migration: {typeof(TContext).Name}");
                    CallSeeder(seeder, context , services);
                    logger.LogInformation($"Started Db Completed: {typeof(TContext).Name}");

                }
                catch (SqlException ex)
                {
                    logger.LogError($"An error occured while migrating db: {typeof(TContext).Name}");
                }
            }

            return host;
        }

        private static void CallSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context,
         IServiceProvider services) where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}
