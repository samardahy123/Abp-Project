using System;
using System.Collections.Generic;
using System.Text;
using CoursesAppMVC.Localization;
using Volo.Abp.Application.Services;

namespace CoursesAppMVC;

/* Inherit your application services from this class.
 */
public abstract class CoursesAppMVCAppService : ApplicationService
{
    protected CoursesAppMVCAppService()
    {
        LocalizationResource = typeof(CoursesAppMVCResource);
    }
}
