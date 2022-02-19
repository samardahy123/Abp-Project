using CoursesAppMVC.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CoursesAppMVC.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CoursesAppMVCEntityFrameworkCoreModule),
    typeof(CoursesAppMVCApplicationContractsModule)
    )]
public class CoursesAppMVCDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
