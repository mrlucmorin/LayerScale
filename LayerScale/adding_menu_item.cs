using Eplan.EplApi.Scripting;

public class Test
{

    [Start]
    public void Run()
    {
        new Eplan.EplApi.Gui.Menu().AddMenuItem("test", "XPartsManagementStart");
    }

}