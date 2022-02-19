using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CoursesAppMVC.Data;
using Volo.Abp.DependencyInjection;

namespace CoursesAppMVC.EntityFrameworkCore;

public class EntityFrameworkCoreCoursesAppMVCDbSchemaMigrator
    : ICoursesAppMVCDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCoursesAppMVCDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the CoursesAppMVCDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CoursesAppMVCDbContext>()
            .Database
            .MigrateAsync();
    }
}
