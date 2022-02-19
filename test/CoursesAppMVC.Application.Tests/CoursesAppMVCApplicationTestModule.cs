using Volo.Abp.Modularity;

namespace CoursesAppMVC;

[DependsOn(
    typeof(CoursesAppMVCApplicationModule),
    typeof(CoursesAppMVCDomainTestModule)
    )]
public class CoursesAppMVCApplicationTestModule : AbpModule
{

}
