using Eplan.EplApi.Scripting;

public class TestAction
{

    [DeclareMenu]
    public void Run()
    {
        new Eplan.EplApi.Gui.Menu().AddMenuItem("test", "XPartsManagementStart");
    }



}