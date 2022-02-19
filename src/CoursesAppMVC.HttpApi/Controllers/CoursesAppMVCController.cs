using CoursesAppMVC.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CoursesAppMVC.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CoursesAppMVCController : AbpControllerBase
{
    protected CoursesAppMVCController()
    {
        LocalizationResource = typeof(CoursesAppMVCResource);
    }
}
