using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;

public class SettingContextMenuExtended
{


    [Start]
    public void Set()
    {
        new Settings().SetBoolSetting("USER.EnfMVC.ContextMenuSetting.ShowExtended", true, 0);

        //new Settings().GetBoolSetting("USER.EnfMVC.ContextMenuSetting.ShowExtended",  0);
        //MessageBox.Show(new Settings().GetBoolSetting("USER.EnfMVC.ContextMenuSetting.ShowExtended", 0).ToString());
        //new Settings().SetBoolSetting("USER.EnfMVC.ContextMenuSetting.ShowIdentifier", true, 0);
    }

}