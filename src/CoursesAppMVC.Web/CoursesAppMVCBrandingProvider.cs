using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace CoursesAppMVC.Web;

[Dependency(ReplaceServices = true)]
public class CoursesAppMVCBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CoursesAppMVC";
}
