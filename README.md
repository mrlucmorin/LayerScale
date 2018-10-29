# LayerScale
EPLAN script to facilitate applying an XSL Transform to an EPLAN Layer scheme.

The repository contains a Visual Studio 2017 solution to facilitate editing the script file, but the only needed files are in the *LayerScale* folder:

* LayerScale.cs
* LayerTransform.xsl

Copy those files to a convenient place on your local disk. I recommend placing the script file LayerScale.cs to your EPLAN $(MD_SCRIPTS) folder, and the LayerTransform.xsl file to your EPLAN $(MD_SCHEME) folder.

### Principle of operation
EPLAN layer schemes can be exported to an *.elc file, which is in reality an XML file. As such, we can apply an XSL Transform to that file, and one possibility is to apply a math operation on a specific XML attribute.

For layer scheme files, each layer node has an attribute named *A961*. The provided XSL file applies a multiplier to the value of this attribute for each layer node.

The multiplicand can therefore scale UP (>1), or scale DOWN (<1).

## Follow those steps to use:

1. Load the script in EPLAN: Utilities > Scripts > Load...
1. 
    1. Use the "Scale layer tool" menu point under Utilities
    1. Associate this script to a toolbar button, assigning the Command Line "ScaleLayerAction"
1. Export the current Layer Scheme to file (*.elc)
1. Launch the script by clicking the toolbar button
1. In the dialog, select the 3 paths:
    1. Input scheme which was exported earlier
    1. XSL Transform file provided with script
        1. The XSL Transform file defaults to a scale of "1.25". This can be edited by the user to set to required scale
    1. Output scheme file
1. Click the OK button to start the transformation
1. Import the resulting EPLAN Layer Scheme file (*.elc)

## The MIT License

Copyright © 2018 STLM Inc.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
