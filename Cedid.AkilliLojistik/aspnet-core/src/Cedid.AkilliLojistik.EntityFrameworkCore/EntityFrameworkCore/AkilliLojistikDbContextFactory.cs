using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Cedid.AkilliLojistik.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AkilliLojistikDbContextFactory : IDesignTimeDbContextFactory<AkilliLojistikDbContext>
{
    public AkilliLojistikDbContext CreateDbContext(string[] args)
    {
        AkilliLojistikEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AkilliLojistikDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new AkilliLojistikDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Cedid.AkilliLojistik.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
