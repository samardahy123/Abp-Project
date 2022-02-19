using CoursesAppMVC.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CoursesAppMVC.Permissions;

public class CoursesAppMVCPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CoursesAppMVCPermissions.MyPermission1, L("Permission:MyPermission1"));
        var CoourseGroup = context.AddGroup(CoursesAppMVCPermissions.GroupName, L("Permission:CoursesApp"));

        var CoursesPermission = CoourseGroup.AddPermission(CoursesAppMVCPermissions.Courses.Default, L("Permission:Courses"));
        CoursesPermission.AddChild(CoursesAppMVCPermissions.Courses.Create, L("Permission:Courses.Create"));
        CoursesPermission.AddChild(CoursesAppMVCPermissions.Courses.Edit, L("Permission:Courses.Edit"));
        CoursesPermission.AddChild(CoursesAppMVCPermissions.Courses.Delete, L("Permission:Courses.Delete"));



        var InstructorPermission = CoourseGroup.AddPermission(
    CoursesAppMVCPermissions.Instructors.Default, L("Permission:Instructors"));

        InstructorPermission.AddChild(
            CoursesAppMVCPermissions.Instructors.Create, L("Permission:Instructors.Create"));

        InstructorPermission.AddChild(
            CoursesAppMVCPermissions.Instructors.Edit, L("Permission:Instructors.Edit"));

        InstructorPermission.AddChild(
            CoursesAppMVCPermissions.Instructors.Delete, L("Permission:Instructors.Delete"));

        var StudentPermission = CoourseGroup.AddPermission(
   CoursesAppMVCPermissions.Students.Default, L("Permission:Students"));

        StudentPermission.AddChild(
            CoursesAppMVCPermissions.Students.Create, L("Permission:Students.Create"));

        StudentPermission.AddChild(
            CoursesAppMVCPermissions.Students.Edit, L("Permission:Students.Edit"));

        StudentPermission.AddChild(
            CoursesAppMVCPermissions.Students.Delete, L("Permission:Students.Delete"));


    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CoursesAppMVCResource>(name);
    }
}
