namespace DecentDubs.UserService.Utilities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DecentDubsDbContextFactory : IDesignTimeDbContextFactory<DecentDubsDbContext>
{
    public DecentDubsDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            connectionString = configuration["Values:DB_CONNECTION_STRING"];
        }

        var optionsBuilder = new DbContextOptionsBuilder<DecentDubsDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new DecentDubsDbContext(optionsBuilder.Options);
    }
}
