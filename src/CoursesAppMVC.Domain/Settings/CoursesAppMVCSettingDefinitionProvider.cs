using Volo.Abp.Settings;

namespace CoursesAppMVC.Settings;

public class CoursesAppMVCSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CoursesAppMVCSettings.MySetting1));
    }
}
