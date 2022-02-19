using CoursesAppMVC.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CoursesAppMVC;

[DependsOn(
    typeof(CoursesAppMVCEntityFrameworkCoreTestModule)
    )]
public class CoursesAppMVCDomainTestModule : AbpModule
{

}
