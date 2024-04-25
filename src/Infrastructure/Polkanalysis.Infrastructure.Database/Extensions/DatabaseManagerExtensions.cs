using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Polkanalysis.Infrastructure.Database.Extensions
{
    public static class DatabaseManagerExtensions
    {
        public static async Task<IHost> ApplyMigrationAsync(this IHost host, ILogger logger)
        {
            logger.LogInformation("Ensure database is ready and created");

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbContext = services.GetRequiredService<SubstrateDbContext>();

                    var nbTotalMigrations = dbContext.Database.GetMigrations().Count();
                    var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
                    if (pendingMigrations.Count() == 0)
                    {
                        logger.LogInformation("No pending migrations");
                        return host;
                    }
                    else
                    {
                        if(nbTotalMigrations == pendingMigrations.Count())
                        {
                            logger.LogInformation("New database detected");
                        }
                        
                        logger.LogInformation("Applying {nbMigration} migrations...", pendingMigrations.Count());
                    }

                    logger.LogInformation("Pending migrations (x{nbMigrations}): \n\t{pendingMigrations}", pendingMigrations.Count(), string.Join("\n\t", pendingMigrations));

                    await dbContext.Database.MigrateAsync();

                    logger.LogInformation("Migrations successfully applied !");

                    var appliedMigrations = await dbContext.Database.GetAppliedMigrationsAsync();
                    logger.LogDebug("Applied migrations : \n\t{appliedMigrations}", string.Join("\n\t", appliedMigrations));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error applying EF Core migration");
                }
            }

            return host;
        }
    }
}
