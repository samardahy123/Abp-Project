using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CoursesAppMVC.Data;

/* This is used if database provider does't define
 * ICoursesAppMVCDbSchemaMigrator implementation.
 */
public class NullCoursesAppMVCDbSchemaMigrator : ICoursesAppMVCDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
