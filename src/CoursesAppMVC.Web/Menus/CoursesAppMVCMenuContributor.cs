using System.Threading.Tasks;
using CoursesAppMVC.Localization;
using CoursesAppMVC.MultiTenancy;
using CoursesAppMVC.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace CoursesAppMVC.Web.Menus;

public class CoursesAppMVCMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<CoursesAppMVCResource>();

        var CoursesAppMenu = new ApplicationMenuItem(
               "coursesApp",
               l["Menu:CourseApp"],
               icon: "fa fa-Course"
           );

        context.Menu.AddItem(CoursesAppMenu);

        if (await context.IsGrantedAsync(CoursesAppMVCPermissions.Courses.Default))
        {
            CoursesAppMenu.AddItem(new ApplicationMenuItem(
                "CoursesApp.Courses",
                l["Menu:Courses"],
                url: "/Courses"
            ));
        }

        if (await context.IsGrantedAsync(CoursesAppMVCPermissions.Instructors.Default))
        {
            CoursesAppMenu.AddItem(new ApplicationMenuItem(
                "CoursesApp.Instructors",
                l["Menu:Instructors"],
                url: "/Instructors"
            ));
        }
        if (await context.IsGrantedAsync(CoursesAppMVCPermissions.Students.Default))
        {
            CoursesAppMenu.AddItem(new ApplicationMenuItem(
               "CoursesApp.Students",
               l["Menu:Students"],
               url: "/Students"
           ));
        }


        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
