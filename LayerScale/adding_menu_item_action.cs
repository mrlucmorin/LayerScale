using Eplan.EplApi.Scripting;

public class AddingMenuItem
{

    //	[DeclareAction("TestAction")]
    //public void Run()
    //	{

    //}


    [DeclareMenu]
    public void new_menu_add()
    {
        new Eplan.EplApi.Gui.Menu().AddMenuItem("test", "XPartsManagementStart");
    }


    [DeclareUnregister]
    public void new_menu_remove()
    {
        new Eplan.EplApi.Gui.Menu().RemoveMenuItem("test", "XPartsManagementStart");
    }
}