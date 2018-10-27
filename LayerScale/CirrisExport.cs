using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;
using System.Windows.Forms;


class CirrisExport
{
    [Start]
    public void Export()
    {

        //Start by exporting the labeling data<

        string strLabelAction = @"label /CONFIGSCHEME:Cirris_Testing /LANGUAGE:en_US /DESTINATIONFILE:C:\temp\cirris_labeling.txt";
        CommandLineInterpreter cli = new CommandLineInterpreter();
        cli.Execute(strLabelAction);

        Progress prg = new Progress("SimpleProgress");
        prg.SetTitle("Exporting Cirris Test File");
        prg.SetOverallActionText("Exporting data");

        prg.ShowImmediately();
        prg.SetAllowCancel(false);
        prg.SetNeededParts(1);

        //Merge files
        var files = new[] { @"c:\temp\prefix.txt", @"c:\temp\cirris_labeling.txt", @"c:\temp\suffix.txt" };
        prg.SetNeededSteps(files.Length);

        using (var output = System.IO.File.Create(@"c:\temp\Final_Output.txt"))
        {
            foreach (var file in files)
            {
                prg.Step(1);
                using (var input = System.IO.File.OpenRead(file))
                {
                    input.CopyTo(output);
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        prg.EndPart(true);
        prg.Dispose();

        System.Windows.Forms.MessageBox.Show("File 'Final_Output.txt' generated.", "Export completed");

    }
}
