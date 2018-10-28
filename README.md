# LayerScale
EPLAN script to facilitate applying an XSL Transform to an EPLAN Layer scheme.

1) User must associate this script to a toolbar button, assigning the Command Line "ScaleLayerAction"
2) User must export the current Layer Scheme to file (*.elc)
3) User must launch the script by clicking the toolbar button
4) User must select the 3 paths:
    a) Input scheme which was exported at step 2)
    b) XSL Transform file provided with script
        i) The XSL Transform file defaults to a scale of "1.25". This can be edited by the user to set to required scale
    c) Output scheme file
5) User must click the OK button to start the transformation
6) User must load the resulting EPLAN Layer Scheme file
