using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;
using System.Windows.Forms;

public class SettingChangeFont
{

    [Start]
    public void Set()
    {
        MultiLangString oMLS = new MultiLangString();
        oMLS.SetAsString("??_??@Arial;");
        new Settings().SetMultiLangStringSetting("COMPANY.GedViewer.Fonts", oMLS);


        MessageBox.Show(new Settings().GetMultiLangStringSetting("COMPANY.GedViewer.Fonts", 4).GetAsString());
    }

}