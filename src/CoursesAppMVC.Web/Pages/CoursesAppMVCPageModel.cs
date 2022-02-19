using CoursesAppMVC.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CoursesAppMVC.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CoursesAppMVCPageModel : AbpPageModel
{
    protected CoursesAppMVCPageModel()
    {
        LocalizationResourceType = typeof(CoursesAppMVCResource);
    }
}
