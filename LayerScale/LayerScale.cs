/*
Luc Morin (MRN), October 2018

Script to scale EPLAN P8 layers.

1) User must associate this script to a toolbar button, assigning the Action name "ScaleLayerAction"
2) User must export the current Layer Scheme to file (*.elc)
3) User must launch the script by clicking the toolbar button
4) User must select the 3 paths:
    a) Input scheme which was exported at step 2)
    b) XSL Transform file provided with script
        i) The XSL Transform file defaults to a scale of "1.25". This can be edited by the user to set to required scale
        ii) 
    c) Output scheme file
5) User must click the OK button to start the transformation
6) User must load the resulting EPLAN Layer Scheme file
 
 
*/


/*
The following compiler directive is necessary to enable editing scripts
within Visual Studio.

It requires that the "Conditional compilation symbol" SCRIPTENV be defined 
in the Visual Studio project properties

This is because EPLAN's internal scripting engine already adds "using directives"
when you load the script in EPLAN. Having them twice would cause errors.
*/

#if SCRIPTENV
using Eplan.EplApi.Scripting;
using Eplan.EplApi.Base;
using System;
using System.Windows.Forms;
#endif

/*
On the other hand, some namespaces are not automatically added by EPLAN when
you load a script. Those have to be outside of the previous conditional compiler directive
*/

using System.ComponentModel;

public class RegisterScriptMenu
{

    //Our Action declaration
    [DeclareAction("ScaleLayerAction")]
    public void Action()
    {
        LayerScaleForm form = new LayerScaleForm();
        form.ShowDialog();
    }

    [DeclareMenu] 
    public void MenuFunction()
    {
        Eplan.EplApi.Gui.Menu oMenu = new Eplan.EplApi.Gui.Menu();
        oMenu.AddMenuItem("Scale layers tool", "ScaleLayerAction");
    }
}

public class FormData : INotifyPropertyChanged
{

    string _inputSchemePath;
    public string InputSchemePath
    {
        get
        {
            return _inputSchemePath;
        }
        set
        {
            if (_inputSchemePath != value)
            {
                _inputSchemePath = value;
                OnPropertyChanged("InputSchemePath");
            }
        }
    }

    string _xslTransformPath;
    public string XslTransformPath
    {
        get
        {
            return _xslTransformPath;
        }
        set
        {
            if (_xslTransformPath != value)
            {
                _xslTransformPath = value;
                OnPropertyChanged("XslTransformPath");
            }
        }
    }

    string outputSchemePath;
    public string OutputSchemePath
    {
        get
        {
            return outputSchemePath;
        }
        set
        {
            if (outputSchemePath != value)
            {
                outputSchemePath = value;
                OnPropertyChanged("OutputSchemePath");
            }
        }
    }

    public bool IsValid
    {
        get
        {
            return !string.IsNullOrEmpty(InputSchemePath) && !string.IsNullOrEmpty(XslTransformPath) && !string.IsNullOrEmpty(OutputSchemePath);
        }
    }

    void OnPropertyChanged(string prop)
    {
        if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
    }
    public event PropertyChangedEventHandler PropertyChanged;


}

public class LayerScaleForm : Form
{

    #region Windows Form Designer generated code

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }


    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        this.tbInputScheme = new System.Windows.Forms.TextBox();
        this.btnSelectInputScheme = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.btnSelectXslTransform = new System.Windows.Forms.Button();
        this.tbXslTransform = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.btnSelectOutputScheme = new System.Windows.Forms.Button();
        this.tbOutputScheme = new System.Windows.Forms.TextBox();
        this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        this.btnCancel = new System.Windows.Forms.Button();
        this.btnOK = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // openFileDialog1
        // 
        this.openFileDialog1.FileName = "";
        // 
        // tbInputScheme
        // 
        this.tbInputScheme.Location = new System.Drawing.Point(132, 16);
        this.tbInputScheme.Name = "tbInputScheme";
        this.tbInputScheme.ReadOnly = true;
        this.tbInputScheme.Size = new System.Drawing.Size(529, 20);
        this.tbInputScheme.TabIndex = 0;
        // 
        // btnSelectInputScheme
        // 
        this.btnSelectInputScheme.Location = new System.Drawing.Point(667, 14);
        this.btnSelectInputScheme.Name = "btnSelectInputScheme";
        this.btnSelectInputScheme.Size = new System.Drawing.Size(28, 23);
        this.btnSelectInputScheme.TabIndex = 1;
        this.btnSelectInputScheme.Text = "...";
        this.btnSelectInputScheme.UseVisualStyleBackColor = true;
        this.btnSelectInputScheme.Click += new System.EventHandler(this.btnSelectInputScheme_Click);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(18, 19);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(73, 13);
        this.label1.TabIndex = 2;
        this.label1.Text = "Layer scheme";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(18, 45);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(100, 13);
        this.label2.TabIndex = 5;
        this.label2.Text = "XSL Transformation";
        // 
        // btnSelectXslTransform
        // 
        this.btnSelectXslTransform.Location = new System.Drawing.Point(667, 40);
        this.btnSelectXslTransform.Name = "btnSelectXslTransform";
        this.btnSelectXslTransform.Size = new System.Drawing.Size(28, 23);
        this.btnSelectXslTransform.TabIndex = 4;
        this.btnSelectXslTransform.Text = "...";
        this.btnSelectXslTransform.UseVisualStyleBackColor = true;
        this.btnSelectXslTransform.Click += new System.EventHandler(this.btnSelectXslTransform_Click);
        // 
        // tbXslTransform
        // 
        this.tbXslTransform.Location = new System.Drawing.Point(132, 42);
        this.tbXslTransform.Name = "tbXslTransform";
        this.tbXslTransform.ReadOnly = true;
        this.tbXslTransform.Size = new System.Drawing.Size(529, 20);
        this.tbXslTransform.TabIndex = 3;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(18, 71);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(105, 13);
        this.label3.TabIndex = 8;
        this.label3.Text = "Scaled layer scheme";
        // 
        // btnSelectOutputScheme
        // 
        this.btnSelectOutputScheme.Location = new System.Drawing.Point(667, 66);
        this.btnSelectOutputScheme.Name = "btnSelectOutputScheme";
        this.btnSelectOutputScheme.Size = new System.Drawing.Size(28, 23);
        this.btnSelectOutputScheme.TabIndex = 7;
        this.btnSelectOutputScheme.Text = "...";
        this.btnSelectOutputScheme.UseVisualStyleBackColor = true;
        this.btnSelectOutputScheme.Click += new System.EventHandler(this.btnSelectOutputScheme_Click);
        // 
        // tbOutputScheme
        // 
        this.tbOutputScheme.Location = new System.Drawing.Point(132, 68);
        this.tbOutputScheme.Name = "tbOutputScheme";
        this.tbOutputScheme.ReadOnly = true;
        this.tbOutputScheme.Size = new System.Drawing.Size(529, 20);
        this.tbOutputScheme.TabIndex = 6;
        // 
        // btnCancel
        // 
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(549, 115);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 23);
        this.btnCancel.TabIndex = 9;
        this.btnCancel.Tag = "";
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnOK
        // 
        this.btnOK.Location = new System.Drawing.Point(630, 115);
        this.btnOK.Name = "btnOK";
        this.btnOK.Size = new System.Drawing.Size(75, 23);
        this.btnOK.TabIndex = 10;
        this.btnOK.Text = "OK";
        this.btnOK.UseVisualStyleBackColor = true;
        this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        // 
        // LayerScaleForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(717, 150);
        this.Controls.Add(this.btnOK);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.btnSelectOutputScheme);
        this.Controls.Add(this.tbOutputScheme);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.btnSelectXslTransform);
        this.Controls.Add(this.tbXslTransform);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.btnSelectInputScheme);
        this.Controls.Add(this.tbInputScheme);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "LayerScaleForm";
        this.Text = "Layer Scale";
        this.ResumeLayout(false);
        this.PerformLayout();

    }


    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.TextBox tbInputScheme;
    private System.Windows.Forms.Button btnSelectInputScheme;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSelectXslTransform;
    private System.Windows.Forms.TextBox tbXslTransform;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnSelectOutputScheme;
    private System.Windows.Forms.TextBox tbOutputScheme;
    private Button btnCancel;
    private Button btnOK;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    #endregion

    public FormData FormData { get; set; }

    public LayerScaleForm()
    {
        InitializeComponent();

        FormData = new FormData();

        //Bind controls to FormData
        tbInputScheme.DataBindings.Add(new Binding("Text", FormData, "InputSchemePath"));
        tbXslTransform.DataBindings.Add(new Binding("Text", FormData, "XslTransformPath"));
        tbOutputScheme.DataBindings.Add(new Binding("Text", FormData, "OutputSchemePath"));
        btnOK.DataBindings.Add(new Binding("Enabled", FormData, "IsValid"));
    }


    private void btnOK_Click(object sender, EventArgs e)
    {
        ApplyTransform();
        this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
    }

    private void btnSelectInputScheme_Click(object sender, EventArgs e)
    {
        openFileDialog1.FileName = string.Empty;
        openFileDialog1.DefaultExt = "elc";
        openFileDialog1.Filter = "EPLAN Layer Scheme files (*.elc)|*.elc";
        openFileDialog1.InitialDirectory = PathMap.SubstitutePath("$(MD_SCHEME)");
        openFileDialog1.Title = "Select EPLAN layer scheme to transform";
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            FormData.InputSchemePath = openFileDialog1.FileName;
        }
        else
        {
            FormData.InputSchemePath = string.Empty;
        }
    }

    private void btnSelectXslTransform_Click(object sender, EventArgs e)
    {
        openFileDialog1.FileName = string.Empty;
        openFileDialog1.DefaultExt = "xsl";
        openFileDialog1.Filter = "XML transformation file (*.xsl)|*.xsl";
        openFileDialog1.InitialDirectory = PathMap.SubstitutePath("$(MD_SCHEME)");
        openFileDialog1.Title = "Select XSL transform file";
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            FormData.XslTransformPath = openFileDialog1.FileName;
        }
        else
        {
            FormData.XslTransformPath = string.Empty;
        }

    }

    private void btnSelectOutputScheme_Click(object sender, EventArgs e)
    {
        saveFileDialog1.FileName = string.Empty;
        saveFileDialog1.DefaultExt = "elc";
        saveFileDialog1.Filter = "EPLAN Layer Scheme files (*.elc)|*.elc";
        saveFileDialog1.InitialDirectory = PathMap.SubstitutePath("$(MD_SCHEME)");
        saveFileDialog1.Title = "Select resulting EPLAN layer scheme";
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            FormData.OutputSchemePath = saveFileDialog1.FileName;
        }
        else
        {
            FormData.OutputSchemePath = string.Empty;
        }
    }

    private void ApplyTransform()
    {
        var xslt = new System.Xml.Xsl.XslCompiledTransform();
        xslt.Load(FormData.XslTransformPath);
        xslt.Transform(FormData.InputSchemePath, FormData.OutputSchemePath);
        MessageBox.Show("Transform done", "Action completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

}
