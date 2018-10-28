# LayerScale
EPLAN script to facilitate applying an XSL Transform to an EPLAN Layer scheme.

The repository contains a Visual Studio 2017 solution to facilitate editing the script file, but the only needed files are in the *LayerScale* folder:

* LayerScale.cs
* LayerTransform.xsl

Copy those files to a convenient place on your local disk. I recommend placing the script file LayerScale.cs to your EPLAN $(MD_SCRIPTS) folder, and the LayerTransform.xsl file to your EPLAN $(MD_SCHEME) folder.

Follow those steps to use:

1. User must associate this script to a toolbar button, assigning the Command Line "ScaleLayerAction"
1. User must export the current Layer Scheme to file (*.elc)
1. User must launch the script by clicking the toolbar button
1. User must select the 3 paths:
    1. Input scheme which was exported earlier
    1. XSL Transform file provided with script
        1. The XSL Transform file defaults to a scale of "1.25". This can be edited by the user to set to required scale
    1. Output scheme file
1. User must click the OK button to start the transformation
1. User must load the resulting EPLAN Layer Scheme file
