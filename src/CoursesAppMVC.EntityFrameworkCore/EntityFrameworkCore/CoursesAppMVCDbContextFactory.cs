using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CoursesAppMVC.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class CoursesAppMVCDbContextFactory : IDesignTimeDbContextFactory<CoursesAppMVCDbContext>
{
    public CoursesAppMVCDbContext CreateDbContext(string[] args)
    {
        CoursesAppMVCEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CoursesAppMVCDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new CoursesAppMVCDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CoursesAppMVC.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
